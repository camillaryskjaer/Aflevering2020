using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometriii
{
    class Square : Polygon
    {

        public Square(double A) : base(A)
        {
            name = "square";
            a = A;
        }

        public override double CalculateCircumference()
        {
            double cirmumference = a * 4;

            return cirmumference;
        }

        public override double CalculateArea()
        {
            double area = a * a;

            return area;
        }
    }
}
