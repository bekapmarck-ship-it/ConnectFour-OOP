using ConnectFour.Models;
using ConnectFour.Views;
using ConnectFour.Players;
using System.Threading;

namespace ConnectFour.Controllers
{
    internal class GameController
    {
        private Board board;
        private ConsoleView view;
        private Player player1;
        private Player player2;

        public GameController()
        {
            board = new Board();
            view = new ConsoleView();

            // Fixed names
            player1 = new HumanPlayer { Name = "Johnson", Symbol = 'X' };
            player2 = new HumanPlayer { Name = "Ariane", Symbol = 'O' };
        }

        public void StartGame()
        {
            bool playAgain = true;

            while (playAgain)
            {
                board = new Board();
                Player currentPlayer = player1;

                while (true)
                {
                    view.DisplayBoard(board.GetGrid());

                    Thread.Sleep(300);

                    view.ShowTurn(currentPlayer.Name, currentPlayer.Symbol);

                    int column = currentPlayer.GetMove();

                    if (!board.DropDisc(column, currentPlayer.Symbol))
                    {
                        view.ShowMessage("Invalid move! Try again.");
                        continue;
                    }

                    view.DisplayBoard(board.GetGrid());

                    if (board.CheckWin(currentPlayer.Symbol))
                    {
                        view.ShowMessage($"It is a Connect 4. {currentPlayer.Name} Wins!");
                        break;
                    }

                    if (board.IsFull())
                    {
                        view.ShowMessage("It's a draw!");
                        break;
                    }

                    if (currentPlayer is ComputerPlayer)
                    {
                        Thread.Sleep(800);
                    }

                    currentPlayer = (currentPlayer == player1) ? player2 : player1;
                }

                view.ShowMessage("Restart? Yes(1) No(0): ");
                string input = Console.ReadLine();

                playAgain = (input == "1");
            }

            view.ShowMessage("Thanks for playing!");
        }
    }
}