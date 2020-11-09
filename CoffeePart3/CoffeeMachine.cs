using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    //Class for my CoffeMachine Object
    class CoffeeMachine
    {
        private int beans;
        private int water;
        private bool filter;
        private bool power;

        public int Beans
        {
            get { return beans; }
            set { beans = value; }
        }
        public int Water
        {
            get { return water; }
            set { water = value; }
        }
        public bool Filter
        {
            get { return filter; }
            set { filter = value; }
        }
        public bool Power
        {
            get { return power; }
            set { power = value; }
        }

        public void AddWater()
        {
            Water++;
        }

        public void AddBeans()
        {
            Beans++;
        }

        public void AddFilter()
        {
            filter = true;
        }

        public void PowerOn()
        {
            Power = true;
        }

        public void PowerOff()
        {
            Power = false;
        }

        public Drink MakeCupOfCoffee()
        {
            if(water >= 1 && beans >= 1 && filter && power)
            {
                water--;
                beans--;
                return new CupOfCoffee();

            }
            else
            {
                return new CupOfNothing();
            }

        }
        public Drink MakeCupOfTea()
        {
            if (water >= 1 && power)
            {
                water--;
                return new CupOfTea();

            }
            else
            {
                return new CupOfNothing();
            }
        }

        public Drink MakeCupOfEspresso()
        {
            if (water >= 1 && beans >= 1 && filter && power)
            {
                water--;
                beans--;
                return new CupOfEspresso();

            }
            else
            {
                return new CupOfEspresso();
            }
        }


    }
}
