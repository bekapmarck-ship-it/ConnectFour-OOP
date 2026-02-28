using ConnectFour.Controllers;

namespace ConnectFour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameController game = new GameController();
            game.StartGame();
        }
    }
}