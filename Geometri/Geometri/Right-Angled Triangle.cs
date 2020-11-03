using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometriii
{
    class Right_Angled_Triangle : Polygon
    {
        public double b { get; set; }
        public double c { get; set; }

        public Right_Angled_Triangle(double A, double B, double C) : base(A)
        {
            name = "right angled triangle";
            a = A;
            b = B;
            c = C;
        }

        public override double CalculateCircumference()
        {
            return a + b + c;

        }

        public override double CalculateArea()
        {
            return 0.5 * a * b;
        }

        public override string ToString()
        {
            return name + "\nArea: " + CalculateArea() + "\nCircumference: " + CalculateCircumference() + "\n";
        }

    }
}
