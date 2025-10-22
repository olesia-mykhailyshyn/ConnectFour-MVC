using ConnectFour.Model;

namespace ConnectFour.Controller;

public sealed class RandomStrategy : IComputerStrategy
{
    public int ChooseColumn(Board board, Cell who, Random rng)
    {
        var options = new List<int>();
        for (int c = 0; c < Board.Cols; c++)
            if (!board.ColumnFull(c))
                options.Add(c);

        return options.Count == 0 ? 0 : options[rng.Next(options.Count)];
    }
}
