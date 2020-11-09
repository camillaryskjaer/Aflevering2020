        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
        }

        public void PrintCreatedDrinks(List<Drink> drinks)
        {
            for (int i = 0; i < drinks.Count; i++)
            {
                Console.WriteLine("Drink "+(i+1)+":\n"+drinks[i].ToString());
            }
            
        }
    }
}
