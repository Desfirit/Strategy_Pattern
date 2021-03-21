using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy_Pattern
{
    public abstract class Player
    {
        public Figure Figure { get; set; }
        public Player(Figure figure)
        {
            Figure = figure;
        }

        public virtual uint MakeMove(Board board)
        {
            throw new System.NotImplementedException();
        }
    }
}