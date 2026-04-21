using System;

namespace ConnectFour.Views
{
    internal class ConsoleView
    {
        public void DisplayBoard(char[,] grid)
        {
            Console.Clear();
            Console.WriteLine("Connect 4 Game Development Project:\n");

            for (int r = 0; r < grid.GetLength(0); r++)
            {
                Console.Write("| ");
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    char cell = grid[r, c];

                    if (cell == 'X')
                        Console.ForegroundColor = ConsoleColor.Red;
                    else if (cell == 'O')
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write((cell == '.' ? '#' : cell) + " ");
                    Console.ResetColor();
                }
                Console.WriteLine("|");
            }

            Console.Write("| ");
            for (int i = 1; i <= 7; i++) Console.Write(i + " ");
            Console.WriteLine("|\n");
        }

        public void ShowMessage(string msg)
        {
            Console.ResetColor();
            Console.WriteLine(msg);
        }

        public void ShowTurn(string name, char symbol)
        {
            Console.ForegroundColor = symbol == 'X'
                ? ConsoleColor.Red
                : ConsoleColor.Yellow;

            Console.WriteLine($"\n{name}'s turn ({symbol})");
            Console.ResetColor();
        }
    }
}