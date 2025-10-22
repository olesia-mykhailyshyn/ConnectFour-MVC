namespace ConnectFour.Model;

public sealed class Game : IGameReadOnly
{
    private readonly IWinRule _winRule;

    public Game(IWinRule winRule)
    {
        _winRule = winRule;
    }

    public Board Board { get; } = new();
    public Cell Current { get; private set; } = Cell.Red;
    public bool IsOver { get; private set; }
    public Cell? Winner { get; private set; }

    public event Action? BoardChanged;
    public event Action<Cell>? CurrentPlayerChanged;
    public event Action<Cell?>? GameEnded;

    public bool TryMakeMove(int column)
    {
        if (IsOver) return false;

        if (!Board.TryDrop(Current, column, out _))
            return false;

        BoardChanged?.Invoke();

        if (_winRule.CheckWin(Board, Current))
        {
            Winner = Current;
            IsOver = true;
            GameEnded?.Invoke(Winner);
            return true;
        }

        if (Board.IsFull())
        {
            Winner = null;
            IsOver = true;
            GameEnded?.Invoke(Winner);
            return true;
        }

        Current = Current == Cell.Red ? Cell.Yellow : Cell.Red;
        CurrentPlayerChanged?.Invoke(Current);
        return true;
    }
}
