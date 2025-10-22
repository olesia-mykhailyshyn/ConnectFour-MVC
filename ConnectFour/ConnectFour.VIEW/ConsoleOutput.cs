using ConnectFour.Model;

namespace ConnectFour.View;

public sealed class ConsoleOutput : IOutput
{
    public void Info(string message)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void Render(Board b)
    {
        Console.WriteLine();
        for (int i = 1; i <= Board.Cols; i++) Console.Write($"{i} ");
        Console.WriteLine();
        for (int r = 0; r < Board.Rows; r++)
        {
            for (int c = 0; c < Board.Cols; c++)
            {
                Console.Write('|');
                Console.Write(b[r, c].ToChar());
            }
            Console.WriteLine('|');
        }
        Console.WriteLine();
    }
}
