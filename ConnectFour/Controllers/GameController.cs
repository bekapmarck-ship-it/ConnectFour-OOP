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

            view.ShowMessage("Select Game Mode:");
            view.ShowMessage("1. HumanPlayer vs HumanPlayer");
            view.ShowMessage("2. HumanPlayer vs AI");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                view.ShowMessage("Enter 1 or 2:");
            }

            player1 = new HumanPlayer { Name = "Johnson", Symbol = 'X' };

            if (choice == 1)
                player2 = new HumanPlayer { Name = "Ariane", Symbol = 'O' };
            else
                player2 = new ComputerPlayer(board) { Name = "AI", Symbol = 'O' };
        }

        public void StartGame()
        {
            bool playAgain = true;

            while (playAgain)
            {
                board = new Board();

                if (player2 is ComputerPlayer ai)
                    ai.SetBoard(board);

                Player currentPlayer = player1;

                while (true)
                {
                    view.DisplayBoard(board.GetGrid());

                    Thread.Sleep(300);
                    view.ShowTurn(currentPlayer.Name, currentPlayer.Symbol);

                    if (currentPlayer is ComputerPlayer)
                        Thread.Sleep(800);

                    int column = currentPlayer.GetMove();

                    if (!board.DropDisc(column, currentPlayer.Symbol))
                    {
                        view.ShowMessage("Invalid move!");
                        continue;
                    }

                    view.DisplayBoard(board.GetGrid());

                    if (board.CheckWin(currentPlayer.Symbol))
                    {
                        view.ShowMessage($"🎉 {currentPlayer.Name} Wins!");
                        break;
                    }

                    if (board.IsFull())
                    {
                        view.ShowMessage("It's a draw!");
                        break;
                    }

                    currentPlayer = (currentPlayer == player1) ? player2 : player1;
                }

                view.ShowMessage("Restart? Yes(1) No(0): ");
                playAgain = Console.ReadLine() == "1";
            }

            view.ShowMessage("Thanks for playing!");
        }
    }
}