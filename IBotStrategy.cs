using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy_Pattern
{
    public interface IBotStrategy
    {
        uint CalculatePosition(Board board, Figure computerFigure);
    }
}