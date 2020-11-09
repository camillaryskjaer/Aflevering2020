using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    class Controller
    {
        Program gui = new Program();

        List<Drink> drinks = new List<Drink>();


        public Controller()
        {
            Main();
        }

        public void Main()
        {
            CoffeeMachine cm = new CoffeeMachine();

            MakeCupsOfCoffee(3, cm);

            gui.PrintCreatedDrinks(drinks);

            Console.ReadKey();
        }

        public void MakeCupsOfCoffee(int amount, CoffeeMachine cm)
        {
            for (int i = 0; i < amount; i++)
            {
                cm.AddBeans();
                cm.AddWater();
            }
            cm.AddFilter();
            cm.PowerOn();

            for (int i = 0; i < amount; i++)
            {
                drinks.Add(cm.MakeCupOfCoffee());

            }

            cm.Filter = false;
            cm.PowerOff();

        }
    }
}
