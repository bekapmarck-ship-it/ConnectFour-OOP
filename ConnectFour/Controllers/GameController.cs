using ConnectFour.Models;
using ConnectFour.Views;
using ConnectFour.Players;

namespace ConnectFour.Controllers
{
    internal class GameController
    {
        public void StartGame()
        {
            Board board = new Board();
            ConsoleView view = new ConsoleView();

            Player player1 = new HumanPlayer { Name = "Player 1", Symbol = 'X' };
            Player player2 = new HumanPlayer { Name = "Player 2", Symbol = 'O' };

            view.ShowMessage("Welcome to Connect Four!");
            view.DisplayBoard(board.GetGrid());
        }
    }
}