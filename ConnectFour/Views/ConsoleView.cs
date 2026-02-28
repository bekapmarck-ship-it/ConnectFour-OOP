using System;

namespace ConnectFour.Views
{
    internal class ConsoleView
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayBoard(char[,] grid)
        {
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    Console.Write(grid[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}