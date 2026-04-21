using ConnectFour.Models;
using ConnectFour.Views;
using ConnectFour.Players;

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
            view.ShowMessage("1. Human vs Human");
            view.ShowMessage("2. Human vs Computer");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                view.ShowMessage("Invalid choice. Enter 1 or 2:");
            }

            player1 = new HumanPlayer { Name = "Player 1", Symbol = 'X' };

            if (choice == 1)
            {
                player2 = new HumanPlayer { Name = "Player 2", Symbol = 'O' };
            }
            else
            {
                player2 = new ComputerPlayer(board) { Name = "Computer", Symbol = 'O' };
            }
        }

        public void StartGame()
        {
            bool playAgain = true;

            while (playAgain)
            {
                board = new Board(); // reset board
                Player currentPlayer = player1;
                while (true)
                {
                    view.DisplayBoard(board.GetGrid());

                    view.ShowTurn(currentPlayer.Name, currentPlayer.Symbol);

                    int column = currentPlayer.GetMove();

                    if (!board.DropDisc(column, currentPlayer.Symbol))
                    {
                        view.ShowMessage("Invalid move! Try again.");
                        continue;
                    }

                    // Show updated board AFTER move
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

                    // small delay ONLY for computer
                    if (currentPlayer is ComputerPlayer)
                    {
                        Thread.Sleep(700);
                    }

                    currentPlayer = (currentPlayer == player1) ? player2 : player1;
                }
                // 🔁 Restart prompt (updated style)
                view.ShowMessage("Restart? Yes(1) No(0): ");
                string input = Console.ReadLine();

                if (input != "1")
                {
                    playAgain = false;
                }
            }

            view.ShowMessage("Thanks for playing!");
        }
    }
}