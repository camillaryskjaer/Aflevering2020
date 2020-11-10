using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAround
{
    interface IFlyingBird
    {
        void SetAltitude(double altitude);
        void Fly();
    }
}
