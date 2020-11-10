using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAround
{
    class Program
    {
        static void Main(string[] args)
        {
            Bird bird1 = new Penguin("Pengu");
            Bird bird2 = new Duck("Duke");
            Bird bird3 = new Ostrich("Oscar");

            Console.WriteLine("Wings: " + bird1.HasWings);
            Console.WriteLine("Eggs: " + bird1.LayingEggs);
            Console.WriteLine("Name: " + bird1.Name);

            Console.WriteLine(bird1.Draw());

            Console.ReadKey();

        }
    }
}
