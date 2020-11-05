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
            //Flot
            private set { a = value; }
        }

        public Polygon(double A)
        {
            name = "square";
            a = A;
        }

        //Her er det super vigtigt at du får dokumenteret din metode fordi du bryder med regnereglerne.
        //Jeg forstår godt at du tænker at lave en default metode, men hvad tror du der sker, hvis man glemmer at overskrive metoden ned i rectangle?
        //Her forudsætter du at alle sider altid er lige lange
        public virtual double CalculateCircumference()
        {
            return (a * 4);
        }

        public virtual double CalculateArea()
        {
            return (a * a);
        }

        //Fint med overskrivelse af ToString
        public override string ToString()
        {

            return name+"\nArea: " + CalculateArea() + "\nCircumference: " + CalculateCircumference()+"\n";
        }

    }
}
