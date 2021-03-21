using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy_Pattern
{
    public class SmartPlay : IBotStrategy
    {
        public uint CalculatePosition(Board board, Figure computerFigure)
        {
            var boardCopy = new Board(board);

            var human = computerFigure == Figure.CROSS ? Figure.ZERO : Figure.CROSS;

            bool found;
            uint pos;
            for(pos = 0, found = false; pos < 9; ++pos)
            {
                if(boardCopy.IsLegal(pos))
                {
                    boardCopy.SetFigure(pos, computerFigure);
                    
                    found = boardCopy.Winner(human,computerFigure) == Winner.COMPUTER;

                    boardCopy.SetFigure(pos, Figure.EMPTY);
                }
                if (found)
                    return pos;
            }

            for (pos = 0; pos < 9; ++pos)
            {
                if (boardCopy.IsLegal(pos))
                {
                    boardCopy.SetFigure(pos, human);
                    found = boardCopy.Winner(human, computerFigure) == Winner.HUMAN;
                    boardCopy.SetFigure(pos, Figure.EMPTY);
                }
                if (found)
                    return pos;
            }

            uint[] BEST_MOVES = { 4, 0, 2, 6, 8, 1, 3, 5, 7 };
            for(int i = 0; i < BEST_MOVES.Length; ++i)
            {
                pos = BEST_MOVES[i];
                found = boardCopy.IsLegal(pos);
                if (found)
                    return pos;
            }

            return pos;

        }
    }
}