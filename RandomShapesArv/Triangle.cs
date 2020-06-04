using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RandomShapesArv
{
    class Triangle : Shape
    {
        private int Size;
        private int _minimumSize = 1;

        public Triangle(Random randomize, int maxSize)
            : base(randomize)
        {
            Size = randomize.Next(_minimumSize, maxSize);
            X = randomize.Next(0, maxSize - Size);
            Y = randomize.Next(0, maxSize - Size);
        }

        public override string GetCharacter(int row, int col)
        {
            if (row < Y || col < X - 1) return null;
            var internalX = col - X;
            var internalY = row - Y;
            if (internalX > 2 * Size + 2 || internalY > Size + 1) return null;
            if (internalY == Size + 1) return "-";
            var xPositionSlash = Size - internalY;
            var xPositionBackslash = Size + internalY + 1;
            if (internalX == xPositionSlash) return "/";
            if (internalX == xPositionBackslash) return "\\";
            return null;
        }
        
    }
}
