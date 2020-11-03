using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometriii
{
    class Rectangle : Polygon
    {
        public double b { get; set; }

        public Rectangle(double A,  double B) :base(A)
        {
            name = "rectangle";
            a = A;
            b = B;
        }

        public override double CalculateCircumference()
        {
            double cirmumference = 2 * (a + b);

            return cirmumference;
        }

        public override double CalculateArea()
        {
            double area = a * b;

            return area;
        }

        

    }
}
