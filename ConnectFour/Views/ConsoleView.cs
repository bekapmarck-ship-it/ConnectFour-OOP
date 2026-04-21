using System;

namespace ConnectFour.Views
{
    internal class ConsoleView
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        public void ShowTurn(string playerName, char symbol)
        {
            if (symbol == 'X')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.WriteLine($"\n{playerName}'s turn ({symbol})");
            Console.ResetColor();
        }

        public void DisplayBoard(char[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            Console.Clear();
            Console.WriteLine("Connect 4 Game Development Project:\n");

            for (int r = 0; r < rows; r++)
            {
                Console.Write("| ");
                for (int c = 0; c < cols; c++)
                {
                    char cell = grid[r, c];

                    if (cell == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X ");
                    }
                    else if (cell == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("O ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("# ");
                    }

                    Console.ResetColor();
                }
                Console.WriteLine("|");
            }

            Console.Write("| ");
            for (int i = 1; i <= cols; i++)
                Console.Write(i + " ");
            Console.WriteLine("|\n");
        }
    }
}