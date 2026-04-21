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

        public void SetBoard(Board newBoard)
        {
            board = newBoard;
        }

        public override int GetMove()
        {
            // Win
            for (int c = 0; c < 7; c++)
            {
                int r = board.GetNextOpenRow(c);
                if (r != -1)
                {
                    board.SetCell(r, c, Symbol);
                    if (board.CheckWin(Symbol))
                    {
                        board.ClearCell(r, c);
                        Console.WriteLine($"{Name} plays column {c + 1} (win)");
                        return c;
                    }
                    board.ClearCell(r, c);
                }
            }

            // Block
            char opp = Symbol == 'X' ? 'O' : 'X';
            for (int c = 0; c < 7; c++)
            {
                int r = board.GetNextOpenRow(c);
                if (r != -1)
                {
                    board.SetCell(r, c, opp);
                    if (board.CheckWin(opp))
                    {
                        board.ClearCell(r, c);
                        Console.WriteLine($"{Name} plays column {c + 1} (block)");
                        return c;
                    }
                    board.ClearCell(r, c);
                }
            }

            // Center
            if (board.GetNextOpenRow(3) != -1) return 3;

            // Random
            int col;
            do { col = rand.Next(0, 7); }
            while (board.GetNextOpenRow(col) == -1);

            return col;
        }
    }
}