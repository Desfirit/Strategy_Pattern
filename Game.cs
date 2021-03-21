using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy_Pattern
{
    public class Game
    {
        private Player[] _players; //Какая разница? инициализировать тут или в конструкторе

        private Board _board; //Какая разница? инициализировать тут или в конструкторе

        public Difficulty Difficulty { get; set; }

        public Game()
        {
            _players = new Player[2];
            _board = new Board();
        }

        

        public void Start()
        {
            _board.ResetBoard();
            Intro();
            Difficulty = AskDifficulty();
            var isHumanFirst = AskFirstMove();

            IBotStrategy botStrategy;
            switch(Difficulty)
            {
                case Difficulty.Easy:
                    botStrategy = new RandomPlay();
                    break;
                case Difficulty.Medium:
                    botStrategy = new SmartPlay();
                    break;
                default:
                    botStrategy = new RandomPlay();
                    break;
            }

            _players[0] = new Computer(botStrategy, isHumanFirst ? Figure.ZERO : Figure.CROSS);
            _players[1] = new Human(isHumanFirst ? Figure.CROSS : Figure.ZERO);

            int order; // ;
            Winner winner;
            for(order = isHumanFirst ? 1 : 0, winner = Winner.NO_ONE; winner == Winner.NO_ONE; ++order, winner = _board.Winner(human: _players[1].Figure, computer: _players[0].Figure))
            {
                var currentPlayer = _players[order%2];

                uint position = currentPlayer.MakeMove(_board);

                _board.SetFigure(position, currentPlayer.Figure);

                if (currentPlayer is Computer)
                    _board.Display();
            }

            switch(winner)
            {
                case Winner.TIE:
                    (_players[0] as Computer).TieWords();
                    break;
                case Winner.COMPUTER:
                    (_players[0] as Computer).WictoryWords();
                    break;
                case Winner.HUMAN:
                    (_players[0] as Computer).LosingWords();
                    break;
            }


            
        }

        public void Intro()
        {
            Console.WriteLine("Welcome to the ultimate man - machine showdown: Tic-Tac-Toe");
            Console.WriteLine("--where human brain is pit against silicon processor");
            Console.WriteLine("Make your move known Ьу entering а number. О - 8. The numbe");
            Console.WriteLine("corresponds to the desired board position. as illustrated:\n");

            Console.WriteLine("\t1 | 2 | 3");
            Console.WriteLine("\t4 | 5 | 6");
            Console.WriteLine("\t7 | 8 | 9\n");
            
            Console.WriteLine("Prepare yourself, human. The battle is about to begin.\n");
        }

        public Difficulty AskDifficulty()
        {
            Console.WriteLine("What level difficulty you'd like: ");

            Console.WriteLine("Easy - 1");
            Console.WriteLine("Medium - 2");

            string input;
            do
            {
                input = Console.ReadKey().KeyChar.ToString();
            } while (input != "1" && input != "2");
            Console.WriteLine();
            Difficulty difficulty = (Difficulty)int.Parse(input);
            return difficulty;
        }

        public bool AskFirstMove()
        {

            Console.Write("Do you require the first move? (y/n): ");

            ConsoleKeyInfo input;
            do
            {
                input = Console.ReadKey();
            } while (input.KeyChar != 'y' && input.KeyChar != 'n');
            Console.WriteLine();
            return input.KeyChar == 'y';

        }
    }
}