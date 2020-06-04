using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace RandomShapesArv
{
    class Program
    {
        private static readonly int _width = 50;
        private static readonly int _height = 20;

        static void Main(string[] args)
        {
            var shapes = CreateShapes();
            var n = 20;
            while (n-- > 0)
            {
                Show(shapes);
                foreach (var shape in shapes)
                {
                    shape.Move();
                }
                Thread.Sleep(400);
            }
        }

        private static Shape[] CreateShapes()
        {
            var random = new Random();
            var shapes = new Shape[5];
            shapes[0] = new Text(5, 2, random, " Wooop!! Wooop!!");
            for (var i = 1; i < shapes.Length; i++)
            {
                if (random.Next(0, 2) == 0)
                    shapes[i] = new Rectangle(random, _width, _height);
                else
                    shapes[i] = new Triangle(random, _height);
            }
            return shapes;
        }

        private static void Show(Shape[] shapes)
        {
            Console.Clear();
            for (var row = 0; row < _height; row++)
            {
                for (var col = 0; col < _width; col++)
                {
                    var characterToPrintFound = false;
                    foreach (var shape in shapes)
                    {
                        var character = shape.GetCharacter(row, col);
                        if (character == null) continue;
                        Console.Write(character);
                        characterToPrintFound = true;
                        break;
                    }
                    if (!characterToPrintFound) Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}