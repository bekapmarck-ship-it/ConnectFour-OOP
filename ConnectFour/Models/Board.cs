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

        public char[,] GetGrid() => grid;

        public bool DropDisc(int column, char symbol)
        {
            if (column < 0 || column >= cols) return false;

            for (int r = rows - 1; r >= 0; r--)
            {
                if (grid[r, column] == '.')
                {
                    grid[r, column] = symbol;
                    return true;
                }
            }
            return false;
        }

        public int GetNextOpenRow(int column)
        {
            for (int r = rows - 1; r >= 0; r--)
                if (grid[r, column] == '.') return r;
            return -1;
        }

        public void SetCell(int r, int c, char s) => grid[r, c] = s;
        public void ClearCell(int r, int c) => grid[r, c] = '.';

        public bool IsFull()
        {
            for (int c = 0; c < cols; c++)
                if (grid[0, c] == '.') return false;
            return true;
        }

        public bool CheckWin(char s)
        {
            // Horizontal
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols - 3; c++)
                    if (grid[r, c] == s && grid[r, c + 1] == s &&
                        grid[r, c + 2] == s && grid[r, c + 3] == s)
                        return true;

            // Vertical
            for (int c = 0; c < cols; c++)
                for (int r = 0; r < rows - 3; r++)
                    if (grid[r, c] == s && grid[r + 1, c] == s &&
                        grid[r + 2, c] == s && grid[r + 3, c] == s)
                        return true;

            // Diagonal /
            for (int r = 3; r < rows; r++)
                for (int c = 0; c < cols - 3; c++)
                    if (grid[r, c] == s && grid[r - 1, c + 1] == s &&
                        grid[r - 2, c + 2] == s && grid[r - 3, c + 3] == s)
                        return true;

            // Diagonal \
            for (int r = 0; r < rows - 3; r++)
                for (int c = 0; c < cols - 3; c++)
                    if (grid[r, c] == s && grid[r + 1, c + 1] == s &&
                        grid[r + 2, c + 2] == s && grid[r + 3, c + 3] == s)
                        return true;

            return false;
        }
    }
}