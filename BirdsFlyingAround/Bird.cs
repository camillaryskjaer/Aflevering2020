using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAround
{
    public abstract class Bird
    {
        public string Name { get; set; }
        public bool HasWings { get; set; }
        public bool LayingEggs { get; set; }

        public abstract void SetLocation(double longitude, double latitude);
        public abstract string Draw();

        public Bird(string n)
        {
            Name = n;
            HasWings = true;
            LayingEggs = true;
        }
    }
}