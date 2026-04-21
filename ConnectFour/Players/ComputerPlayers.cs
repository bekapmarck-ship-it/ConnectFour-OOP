using System;
using ConnectFour.Models;

namespace ConnectFour.Players
{
    internal class ComputerPlayer : Player
    {
        private Random rand = new Random();
        private Board board;

        public ComputerPlayer(Board board)
        {
            this.board = board;
        }

        //  IMPORTANT: update board when game resets
        public void SetBoard(Board newBoard)
        {
            board = newBoard;
        }

        public override int GetMove()
        {
            // 1️⃣ Try to win
            for (int col = 0; col < 7; col++)
            {
                int row = board.GetNextOpenRow(col);
                if (row != -1)
                {
                    board.SetCell(row, col, Symbol);

                    if (board.CheckWin(Symbol))
                    {
                        board.ClearCell(row, col);
                        Console.WriteLine($"{Name} plays column {col + 1} (winning move)");
                        return col;
                    }

                    board.ClearCell(row, col);
                }
            }

            // 2️⃣ Block opponent
            char opponent = (Symbol == 'X') ? 'O' : 'X';

            for (int col = 0; col < 7; col++)
            {
                int row = board.GetNextOpenRow(col);
                if (row != -1)
                {
                    board.SetCell(row, col, opponent);

                    if (board.CheckWin(opponent))
                    {
                        board.ClearCell(row, col);
                        Console.WriteLine($"{Name} plays column {col + 1} (blocking move)");
                        return col;
                    }

                    board.ClearCell(row, col);
                }
            }

            // 3️⃣ Prefer center column (smart move)
            int center = 3;
            if (board.GetNextOpenRow(center) != -1)
            {
                Console.WriteLine($"{Name} plays column {center + 1} (center)");
                return center;
            }

            // 4️⃣ Random valid move
            int randomCol;
            do
            {
                randomCol = rand.Next(0, 7);
            } while (board.GetNextOpenRow(randomCol) == -1);

            Console.WriteLine($"{Name} plays column {randomCol + 1}");
            return randomCol;
        }
    }
}