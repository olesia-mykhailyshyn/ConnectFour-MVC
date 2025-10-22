using ConnectFour.Model;
using ConnectFour.View;

namespace ConnectFour.Controller;

public static class GameFactory
{
    public static (GameController controller, Game game, GameMode mode) Create(IInput input, IOutput output)
    {
        var mode = AskMode(input, output);

        IComputerStrategy? strategy = mode == GameMode.PvE ? new RandomStrategy() : null;
        var controller = new GameController(input, output, strategy);
        var game = new Game(new StandardWinRule());

        return (controller, game, mode);
    }

    private static GameMode AskMode(IInput input, IOutput output)
    {
        while (true)
        {
            output.Info("Оберіть режим: 1 — PvP, 2 — PvE");
            var s = input.ReadLine().Trim();
            if (int.TryParse(s, out var n) && (n == 1 || n == 2))
                return (GameMode)n;
            output.Error("Введіть 1 або 2.");
        }
    }
}
