using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometriii
{
    class Trapezoid : Square
    {
        public double b { get; set; }
        public double c { get; set; }
        public double d { get; set; }

        public Trapezoid(int A, double B, double C, double D) : base(A)
        {
            name = "trapezoid";
            a = A;
            b = B;
            c = C;
            d = D;
        }

        public override double CalculateCircumference()
        {
            double circumference = a + b + c + d;

            return circumference;

        }

        public override double CalculateArea()
        {
            double s = (a + b - c + d) / 2;
            double y = 2 / (a - c);
            double x = s * (s - a + c) * (s - b) * (s - d);
            double h = Convert.ToDouble(Math.Pow(x, y));

            double area = 0.5 * (a + c) * h;


            return area;
        }
    }
}
