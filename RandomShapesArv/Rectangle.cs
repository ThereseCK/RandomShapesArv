using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomShapesArv
{
    class Rectangle : Shape
    {
        public int Height;
        public int Width;
        private int _minimumSize = 3;

        public Rectangle(Random randomize, int maxX, int maxY)
            : base(randomize)
        {

            X = randomize.Next(0, maxX - _minimumSize);
            Y = randomize.Next(0, maxY - _minimumSize);
            Width = randomize.Next(_minimumSize, maxX - X);
            Height = randomize.Next(_minimumSize, maxY - Y);

        }

        public override string GetCharacter(int row, int col)
        {

            if (row == Y && col == X) return "┌";

            if (row == Y && col == X + Width) return "┐";

            if (row == Y + Height && col == X) return "└";

            if (row == Y + Height && col == X + Width) return "┘";


            if (row == Y && col > X && col < X + Width) return "─";

            if (row == Y + Height && col > X && col < X + Width) return "─";

            if (col == X && row > Y && row < Y + Height) return "│";

            if (col == X + Width && row > Y && row < Y + Height) return "│";

            return null;
        }
    }
}