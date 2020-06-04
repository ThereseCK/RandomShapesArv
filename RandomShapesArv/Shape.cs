using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomShapesArv
{
    abstract class Shape
    {
        public int DirectionX { get; internal set; }
        public int DirectionY { get; internal set; }
        public int X { get; internal set; }
        public int Y { get; internal set; }

        protected Shape()
        {
            //ctor- hvis det skal være en annen shape f.eks som er fast eller lignende
            // er ikke den med så kan det hende noen av shapesene ikke beveger seg.
        }

        protected Shape(Random randomize)
        {
            DirectionX = randomize.Next(0, 2);
            DirectionY = randomize.Next(0, 2);

        }

        public void Move()
        {
            X += DirectionX;
            Y += DirectionY;
        }
        public abstract string GetCharacter(int row, int col);
    }
}