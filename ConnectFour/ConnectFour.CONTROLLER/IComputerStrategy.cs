using ConnectFour.Model;

namespace ConnectFour.Controller;

public interface IComputerStrategy
{
    int ChooseColumn(Board board, Cell who, Random rng);
}
