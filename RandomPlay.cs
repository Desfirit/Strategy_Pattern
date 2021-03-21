using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy_Pattern
{
    public class RandomPlay : IBotStrategy
    {

        public uint CalculatePosition(Board board, Figure computerFigure)
        {
            var rand = new Random();
            uint randPos;
            do
            {
                randPos = (uint)rand.Next(9);
            }
            while (!board.IsLegal(randPos));
            return randPos;
        }
    }
}