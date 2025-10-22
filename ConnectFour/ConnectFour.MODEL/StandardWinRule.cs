namespace ConnectFour.Model;

public sealed class StandardWinRule : IWinRule
{
    private static readonly (int dr, int dc)[] dirs =
    [
        (0, 1), (1, 0), (1, 1), (1, -1)
    ];

    public bool CheckWin(Board board, Cell who)
    {
        for (int r = 0; r < Board.Rows; r++)
        for (int c = 0; c < Board.Cols; c++)
        {
            if (board[r, c] != who) continue;
            foreach (var (dr, dc) in dirs)
            {
                int count = 1, rr = r, cc = c;
                while (count < 4)
                {
                    rr += dr; cc += dc;
                    if (rr < 0 || rr >= Board.Rows || cc < 0 || cc >= Board.Cols)
                        break;
                    if (board[rr, cc] != who)
                        break;
                    count++;
                }
                if (count == 4)
                    return true;
            }
        }
        return false;
    }
}
