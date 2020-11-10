using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAround
{
    class Duck : Bird , IFlyingBird
    {
        public override void SetLocation(double longitude, double latitude)
        {
            //sæt en lokation
        }

        public void SetAltitude(double altitude)
        {
            //sæt en højde
        }

        public void Fly()
        {
            //flyv
        }
            
        public override string Draw()
        {
            //Tegn fuglen på skærmen

            return "";

        }

        public Duck(string n) : base(n)
        {
        }

    }
}
