using ConnectFour.Model;

namespace ConnectFour.Test.Model;

[TestFixture]
public class ConnectFourTests
{
    private Game game;

    [SetUp]
    public void SetUp()
    {
        game = new Game(new StandardWinRule());
    }

    [Test]
    public void AfterGameCreated_FirstPlayerIsRed()
    {
        Assert.That(game.Current, Is.EqualTo(Cell.Red));
        Assert.That(game.Winner, Is.Null);
        Assert.That(game.IsOver, Is.False);
    }

    [Test]
    public void Board_ShouldBeEmpty_WhenGameStarts()
    {
        var board = game.Board;

        for (int r = 0; r < Board.Rows; r++)
        for (int c = 0; c < Board.Cols; c++)
        {
            Assert.That(board[r, c], Is.EqualTo(Cell.Empty));
        }
    }

    [Test]
    public void AfterMove_CellIsFilled_AndPlayerSwitches()
    {
        bool success = game.TryMakeMove(3); // column index 3
        Assert.That(success, Is.True);

        Assert.That(game.Board[Board.Rows - 1, 3], Is.EqualTo(Cell.Red));
        Assert.That(game.Current, Is.EqualTo(Cell.Yellow));
    }

    [Test]
    public void GameEnds_WhenPlayerConnectsFourHorizontally()
    {
        // X: Red, O: Yellow
        // Simulate a win for Red horizontally
        for (int i = 0; i < 3; i++)
        {
            game.TryMakeMove(i); // Red
            game.TryMakeMove(6); // Yellow dummy
        }

        game.TryMakeMove(3); // Red completes 4 in a row

        Assert.That(game.IsOver, Is.True);
        Assert.That(game.Winner, Is.EqualTo(Cell.Red));
    }

    [Test]
    public void GameEnds_InDraw_WhenBoardIsFullWithoutWinner()
    {
        var b = game.Board;
        // manually fill board pattern no wins
        var cells = new[] { Cell.Red, Cell.Yellow };
        int index = 0;

        for (int c = 0; c < Board.Cols; c++)
        {
            for (int r = Board.Rows - 1; r >= 0; r--)
            {
                b.TryDrop(cells[index % 2], c, out _);
                index++;
            }
        }

        // emulate check for draw
        game.TryMakeMove(0); // triggers check
        Assert.That(b.IsFull(), Is.True);
        Assert.That(game.IsOver, Is.True);
        Assert.That(game.Winner, Is.Null);
    }
}
