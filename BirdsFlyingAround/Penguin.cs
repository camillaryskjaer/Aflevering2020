using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAround
{
    public class Penguin : Bird
    {
        public override void SetLocation(double longitude, double latitude)
        {
            //sæt en lokation
        }

        public override string Draw()
        {
            //Tegn fuglen på skærmen
            return @" 
                        __
                     -=(o '.
                        '.-.\
                        /|  \\
                        '|  ||
                         _\_):,_
  ";

        }

        public Penguin(string n) :base (n)
        {

        }
    }
}
