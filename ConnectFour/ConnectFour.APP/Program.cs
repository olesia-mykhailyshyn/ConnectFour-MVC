using ConnectFour.Controller;
using ConnectFour.View;

var input = new ConsoleInput();
var output = new ConsoleOutput();

var (controller, game, mode) = GameFactory.Create(input, output);
controller.Run(game, mode);
