using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    //This is my controller class, used to control the application, connected between gui 
    //and logic layer and is overral just responsible for what is happning
    class Controller
    {
        //Object reference to gui layer
        Program gui = new Program();

        //Create list of drinks to store the various drinks createde throughout the application for easy debugging with the 
        //Use of ToString
        List<Drink> drinks = new List<Drink>();

        //Constructor of Controller class to initiate the main method.
        public Controller()
        {
            Main();
        }

        //The main method, the application is controllred from here.
        public void Main()
        {
            //Creating a coffee machine that will be used throughout the application
            CoffeeMachine cm = new CoffeeMachine();

            //UseCoffeeMachine used to create various different drinks. (Coffee, Tea, Espresso)

            UseCoffeeMachine("Coffee", 3, cm );

            UseCoffeeMachine("Tea", 1, cm );

            UseCoffeeMachine("Espresso", 1, cm);
            
            //Printing out the to string method on all the objects that has been created for fast debugging
            gui.PrintCreatedDrinks(drinks);

            //-'
            Console.ReadKey();
        }

        //Method to use CoffeeMachine. Parameters are for the type of drink that should be created,
        //the amount of said drink and what coffemachine object that should be used.
        public void UseCoffeeMachine(string drink, int amount, CoffeeMachine cm)
        {

            //For each loop for each drink that should be created, goes in and calls the PrePareCoffeeMachine method
            //And then creates the drink and adds it to the drinks list
            for (int i = 0; i < amount; i++)
            {
                PrepareCoffeeMachine(cm, drink);
                if (drink == "Coffee")
                {
                    drinks.Add(cm.MakeCupOfCoffee());
                }
                else if (drink == "Espresso")
                {
                    drinks.Add(cm.MakeCupOfEspresso());
                }
                else if (drink == "Tea")
                {
                    drinks.Add(cm.MakeCupOfTea());
                }
            }

            //When all is done it turns the filter to falls(Because it no longe can be used) and turns the power off
            cm.Filter = false;
            cm.PowerOff();
        }


        //Prepares the CoffeeMachine before use by adding water and beas, changing filtering and powering on the machine as need be.
        public void PrepareCoffeeMachine(CoffeeMachine cm, string drink)
        {
            //Coffee and Espresso needs the same preperation
            if (drink == "Coffee" || drink == "Espresso")
            {
                cm.AddBeans();
                cm.AddWater();
                cm.AddFilter();
                cm.PowerOn();
            }
            //Tea :)
            else if (drink == "Tea")
            {
                cm.AddWater();
                cm.PowerOn();
            }

        }
    }


}


