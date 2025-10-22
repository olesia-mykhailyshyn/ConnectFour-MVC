namespace ConnectFour.Model;

public interface IWinRule
{
    bool CheckWin(Board board, Cell who);
}
