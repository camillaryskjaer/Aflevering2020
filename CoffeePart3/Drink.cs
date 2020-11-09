using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    //Drink class is the template for drinks holding default values that are present in all drinks
    //And holds default values incase something goes wrong debugging and better user experiance incase of errors(Better getting an empty cup than having your CoffeeMachine shut down because it is out of beans)
    
    public class Drink
    {
        public int milliliter { get; set; }
        public string flavour { get; set; }

        public Drink()
        {
            milliliter = 0;
            flavour = "none";
        }

        public override string ToString()
        {
            return "Flavour: " + flavour + "\n" + "ML: " + milliliter;
        }

    }
}
