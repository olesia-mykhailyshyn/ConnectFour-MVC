using ConnectFour.Model;

namespace ConnectFour.View;

public interface IOutput
{
    void Render(Board board);
    void Info(string message);
    void Error(string message);
}
