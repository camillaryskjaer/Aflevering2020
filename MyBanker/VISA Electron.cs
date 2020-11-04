using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankeriii
{
    class VISA_Electron : Card
    {
        public VISA_Electron(string name) : base(name)
        {
            CardName = "VISA Electron";
            CardNumber = GenerateCardNumber(16, new string[] { "4026", "417500", "4508", "4844", "4913", "4917" });
        }

        public override string ToString()
        {
            return base.ToString() + "\nVisa Electron er et debetkort, men dette kan bruges internationalt og på Nettet. Kortet udstedes til kunder over 15 år. Der kan max. Bruges 10000 kr om måneden på dette kort.";
        }

    }
}
