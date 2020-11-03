using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometriii
{
    class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square(10);
            Square rectangle = new Rectangle(10, 5);
            Square parallelogram = new Parallelogram(10, 5);
            Square trapozoid = new Trapezoid(16, 8, 8, 8);

            Console.WriteLine(square.ToString());
            Console.WriteLine(rectangle.ToString());
            Console.WriteLine(parallelogram.ToString());
            Console.WriteLine(trapozoid.ToString());
           
            Console.ReadKey();
        }
    }
}
