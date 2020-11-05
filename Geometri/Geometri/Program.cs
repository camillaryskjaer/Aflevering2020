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
            //Syntes opgaven var lidt mærkeligt formuleret men det her var min forståelse af den :P

            //I decided to add the polygon class to include the right angled triangle
            //Then I removed the square class as a super class because I thought only having the polygon as a superclass made more sense.

            //Initilizing the the different objects(Polygons)
           
            //Flot at du husker at bruge polymorfi
            Polygon square = new Square(10);
            Polygon rectangle = new Rectangle(10, 5);
            Polygon parallelogram = new Parallelogram(10, 5);
            Polygon trapozoid = new Trapezoid(16, 8, 8, 8);
            Polygon trekant = new Right_Angled_Triangle(10, 10, 10);

            //Putting the objects in a list
            List <Polygon> polygons = new List<Polygon>();
            polygons.Add(square);
            polygons.Add(rectangle);
            polygons.Add(parallelogram);
            polygons.Add(trapozoid);
            polygons.Add(trekant);

            //Printing out the to string method from polygon which all of them has acess to.
            for (int i = 0; i < polygons.Count; i++)
            {
                Console.WriteLine(polygons[i].ToString());
            }


            Console.ReadKey();
        }
    }
}
