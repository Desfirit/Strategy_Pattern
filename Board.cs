using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy_Pattern
{
    public class Board
    {
        private Figure[] _board;

        public Board()
        {
            _board = new Figure[9];
        }

        public Board(Board board)
        {
            _board = board._board.Clone() as Figure[];
        }

        public void ResetBoard()
        {
            for (var i = 0; i < _board.Length; ++i)
                _board[i] = Figure.EMPTY;
        }

        public bool IsLegal(uint pos)
        {
            return _board[pos] == Figure.EMPTY;
        }

        public void SetFigure(uint pos, Figure figure)
        {
            _board[pos] = figure;
        }

        public void Display()
        {
            Console.WriteLine();
            var copy = new string[_board.Length];
            for (var i = 0; i < _board.Length; ++i)
            {
                string symb = " ";
                switch (_board[i])
                {
                    case Figure.ZERO:
                        symb = "O";
                        break;
                    case Figure.CROSS:
                        symb = "X";
                        break;
                }
                copy[i] = symb;
            }
            Console.WriteLine($"\t{copy[0]} | {copy[1]} | {copy[2]}");
            Console.WriteLine($"\t{copy[3]} | {copy[4]} | {copy[5]}");
            Console.WriteLine($"\t{copy[6]} | {copy[7]} | {copy[8]}");
            Console.WriteLine();
        }

        public Winner Winner(Figure human, Figure computer)
        {
            int[,] WINNING_ROWS = new int[8, 3]{
                { 0, 1, 2},
                { 3, 4, 5},
                { 6, 7, 8},
                { 0, 3, 6},
                { 1, 4, 7},
                { 2, 5, 8},
                { 0, 4, 8},
                { 2, 4, 6}};

            for (int row = 0; row < 8; ++row)
            {
                if ((_board[WINNING_ROWS[row, 0]] != Figure.EMPTY) &&
                    _board[WINNING_ROWS[row, 0]] == _board[WINNING_ROWS[row, 1]] &&
                    _board[WINNING_ROWS[row, 1]] == _board[WINNING_ROWS[row, 2]])
                {
                    return human == _board[WINNING_ROWS[row, 0]] ? Strategy_Pattern.Winner.HUMAN : Strategy_Pattern.Winner.COMPUTER;
                }
            }

            if (_board.Any(a => a == Figure.EMPTY))
                return Strategy_Pattern.Winner.NO_ONE;
            else
                return Strategy_Pattern.Winner.TIE;
        }
    }
}