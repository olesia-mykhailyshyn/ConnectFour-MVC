namespace ConnectFour.View;

public sealed class ConsoleInput : IInput
{
    public string ReadLine() => Console.ReadLine() ?? string.Empty;
}
