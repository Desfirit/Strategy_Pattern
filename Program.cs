using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            ConsoleKeyInfo input;
            do
            {
                game.Start();
                Console.WriteLine("Play again? (y/n)");

                do
                {
                    input = Console.ReadKey();
                } while (input.KeyChar != 'y' && input.KeyChar != 'n');
            } while (input.KeyChar == 'y');

            Console.WriteLine("End program...");
            Console.ReadKey();
        }
    }
}
