namespace ConnectFour.Model;

public enum Cell { Empty = 0, Red = 1, Yellow = 2 }

public static class CellExtensions
{
    public static char ToChar(this Cell c) => c switch
    {
        Cell.Red => 'X',
        Cell.Yellow => 'O',
        _ => ' '
    };
}
