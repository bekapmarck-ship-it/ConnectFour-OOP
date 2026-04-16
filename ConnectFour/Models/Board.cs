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

        public bool DropDisc(int column, char symbol)
        {
            if (column < 0 || column >= cols)
                return false;

            for (int row = rows - 1; row >= 0; row--)
            {
                if (grid[row, column] == '.')
                {
                    grid[row, column] = symbol;
                    return true;
                }
            }
            return false;
        }

        public int GetNextOpenRow(int column)
        {
            for (int row = rows - 1; row >= 0; row--)
            {
                if (grid[row, column] == '.')
                {
                    return row;
                }
            }
            return -1;
        }

        public void SetCell(int row, int column, char symbol)
        {
            grid[row, column] = symbol;
        }

        public void ClearCell(int row, int column)
        {
            grid[row, column] = '.';
        }

        public bool IsFull()
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[0, c] == '.')
                    return false;
            }
            return true;
        }

        public bool CheckWin(char symbol)
        {
            return CheckHorizontal(symbol) ||
                   CheckVertical(symbol) ||
                   CheckDiagonal(symbol);
        }

        private bool CheckHorizontal(char symbol)
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols - 3; c++)
                {
                    if (grid[r, c] == symbol &&
                        grid[r, c + 1] == symbol &&
                        grid[r, c + 2] == symbol &&
                        grid[r, c + 3] == symbol)
                        return true;
                }
            }
            return false;
        }

        private bool CheckVertical(char symbol)
        {
            for (int c = 0; c < cols; c++)
            {
                for (int r = 0; r < rows - 3; r++)
                {
                    if (grid[r, c] == symbol &&
                        grid[r + 1, c] == symbol &&
                        grid[r + 2, c] == symbol &&
                        grid[r + 3, c] == symbol)
                        return true;
                }
            }
            return false;
        }

        private bool CheckDiagonal(char symbol)
        {
            // bottom-left → top-right
            for (int r = 3; r < rows; r++)
            {
                for (int c = 0; c < cols - 3; c++)
                {
                    if (grid[r, c] == symbol &&
                        grid[r - 1, c + 1] == symbol &&
                        grid[r - 2, c + 2] == symbol &&
                        grid[r - 3, c + 3] == symbol)
                        return true;
                }
            }

            // top-left → bottom-right
            for (int r = 0; r < rows - 3; r++)
            {
                for (int c = 0; c < cols - 3; c++)
                {
                    if (grid[r, c] == symbol &&
                        grid[r + 1, c + 1] == symbol &&
                        grid[r + 2, c + 2] == symbol &&
                        grid[r + 3, c + 3] == symbol)
                        return true;
                }
            }

            return false;
        }
    }
}