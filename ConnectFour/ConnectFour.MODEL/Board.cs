namespace ConnectFour.Model;

public sealed class Board
{
    public const int Rows = 6;
    public const int Cols = 7;

    private readonly Cell[,] _grid = new Cell[Rows, Cols];

    public Cell this[int r, int c] => _grid[r, c];

    public bool ColumnFull(int col) => _grid[0, col] != Cell.Empty;

    public bool TryDrop(Cell who, int col, out (int row, int col) pos)
    {
        pos = (-1, col);
        if (col < 0 || col >= Cols || who == Cell.Empty || ColumnFull(col))
            return false;

        for (int r = Rows - 1; r >= 0; r--)
        {
            if (_grid[r, col] == Cell.Empty)
            {
                _grid[r, col] = who;
                pos = (r, col);
                return true;
            }
        }
        return false;
    }

    public bool IsFull() => Enumerable.Range(0, Cols).All(ColumnFull);
}
