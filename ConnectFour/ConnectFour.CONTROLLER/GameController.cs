using ConnectFour.Model;
using ConnectFour.View;

namespace ConnectFour.Controller;

public enum GameMode { PvP = 1, PvE = 2 }

public sealed class GameController
{
    private readonly IInput _input;
    private readonly IOutput _output;
    private readonly IComputerStrategy? _botStrategy;
    private readonly Random _rng = new();

    public GameController(IInput input, IOutput output, IComputerStrategy? strategy = null)
    {
        _input = input;
        _output = output;
        _botStrategy = strategy;
    }

    public void Run(Game game, GameMode mode)
    {
        game.BoardChanged += () => _output.Render(game.Board);
        game.CurrentPlayerChanged += who => 
            _output.Info($"Хід: {(who == Cell.Red ? "X" : "O")}");
        game.GameEnded += winner =>
        {
            if (winner is null) _output.Info("Нічия!");
            else _output.Info($"Переміг {(winner == Cell.Red ? "X" : "O")}");
        };

        _output.Render(game.Board);
        _output.Info($"Починає {(game.Current == Cell.Red ? "X" : "O")}");

        while (!game.IsOver)
        {
            int col;
            if (mode == GameMode.PvE && game.Current == Cell.Yellow)
            {
                col = _botStrategy!.ChooseColumn(game.Board, Cell.Yellow, _rng);
                _output.Info($"Компʼютер обрав колонку {col + 1}");
            }
            else
            {
                col = AskColumn(game);
            }

            if (!game.TryMakeMove(col))
                _output.Error("Невалідний хід. Спробуйте іншу колонку.");
        }
    }

    private int AskColumn(IGameReadOnly g)
    {
        while (true)
        {
            _output.Info($"Гравець {(g.Current == Cell.Red ? "X" : "O")}, оберіть колонку (1-{Board.Cols}):");
            var s = _input.ReadLine().Trim();
            if (int.TryParse(s, out var n) && n >= 1 && n <= Board.Cols)
                return n - 1;
            _output.Error("Невірне число.");
        }
    }
}
