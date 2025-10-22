namespace ConnectFour.Model;

public interface IGameReadOnly
{
    Board Board { get; }
    Cell Current { get; }
    bool IsOver { get; }
    Cell? Winner { get; } // null => draw, Empty => still playing
}
