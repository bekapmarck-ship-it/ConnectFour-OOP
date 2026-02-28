using System;

namespace ConnectFour.Models
{
    internal class Board
    {
        private char[,] grid;
        private int rows = 6;
        private int cols = 7;

        public Board()
        {
            grid = new char[rows, cols];
            Initialize();
        }

        public void Initialize()
        {
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    grid[r, c] = '.';
        }

        public char[,] GetGrid()
        {
            return grid;
        }
    }
}