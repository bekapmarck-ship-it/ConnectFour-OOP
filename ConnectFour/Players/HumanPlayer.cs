using System;

namespace ConnectFour.Players
{
    internal class HumanPlayer : Player
    {
        public override int GetMove()
        {
            Console.Write($"{Name}, choose a column (1-7): ");
            int column = int.Parse(Console.ReadLine());
            return column - 1;
        }
    }
}