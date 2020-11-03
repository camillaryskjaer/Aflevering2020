using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometriii
{
    public class Polygon
    {
        protected string name { get; set; }
        protected double a;

        public double A
        {
            get { return a; }
            private set { a = value; }
        }

        public Polygon(double A)
        {
            name = "square";
            a = A;
        }

        public virtual double CalculateCircumference()
        {
            return (a * 4);
        }

        public virtual double CalculateArea()
        {
            return (a * a);
        }

        public override string ToString()
        {

            return name+"\nArea: " + CalculateArea() + "\nCircumference: " + CalculateCircumference()+"\n";
        }

    }
}
