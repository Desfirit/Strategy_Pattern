using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy_Pattern
{
    public class Human : Player
    {
        public Human(Figure figure) : base(figure) {}

        public override uint MakeMove(Board board) //Фигово, что класс игрока может сам вписать фигуру в доску, шо поделаешь.
        {
            uint pos = AskPosition();
            while (!board.IsLegal(pos))
            {
                Console.WriteLine("That square is already occupied. foolish human");
                pos = AskPosition();
                Console.WriteLine("Fine...");
            }
            return pos;
        }
        private uint AskPosition()
        {
            Console.Write("Enter number of cell (1-9): ");
            uint position;
            do
            {
                var input = Console.ReadKey().KeyChar.ToString();

                if (!uint.TryParse(input, out position))
                {
                    position = uint.MaxValue;
                    continue;
                }
                --position;

            } while (position > 9);
            Console.WriteLine();
            return position;
        }
    }
}