using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometriii
{
    class Parallelogram : Square
    {
        public double b { get; set; }

        public Parallelogram(int A, int B) : base(A)
        {
            name = "parallelogram";
            a = A;
            b = B;
        }

        readonly double sinAngle = Math.Sin(45);


        public override double CalculateCircumference()
        {
            double circumference = (a + b) * 2;

            return circumference;

        }

        public override double CalculateArea()
        {
            double area = a * b * sinAngle;

            return area;
        }

    }
}
