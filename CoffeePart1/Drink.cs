using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class Drink
    {
        public int milliliter { get; set; }
        public string flavour { get; set; }


        public override string ToString()
        {
            return "ML: " + milliliter + "\n" + "Flavour: " + flavour;
        }

    }
}
