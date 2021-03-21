using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy_Pattern
{
    public class Computer : Player
    {

        public IBotStrategy PlayStrategy { get; set; }

        public Computer(IBotStrategy strategy, Figure figure) : base(figure)
        {
            PlayStrategy = strategy;
        }

        public override uint MakeMove(Board board)
        {
            return PlayStrategy.CalculatePosition(board, Figure);
        }

        public void LosingWords()
        {
            Console.WriteLine("Human's won!");
            Console.WriteLine("No, no! It can't be! Somehow you tricked me, human.");
            Console.WriteLine("But never again! I, the computer, so swear it!");
        }

        public void WictoryWords()
        {
            Console.WriteLine("Computer's won!");
            Console.WriteLine("As I predicted, human. I am triumphant once more -- proof");
            Console.WriteLine("That computers are superior to humans in all regards");
        }

        public void TieWords()
        {
            Console.WriteLine("It's а tie.");
            Console.WriteLine("You were most lucky, human, and somehow managed to tie me.");
            Console.WriteLine("Celebrate ... for this is the best you will ever achieve.");
        }
    }
}