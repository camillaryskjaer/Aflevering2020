using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankeriii
{
    class VISA_Dankort : Card
    {
        public VISA_Dankort(string name) : base(name)
        {
            CardName = "VISA Dankort";
            CardNumber = GenerateCardNumber(16, new string[] { "4" });
        }

        public override string ToString()
        {
            return base.ToString() + "\nDette er et delvist kreditkort med en grænse på 20.000 kr. Man skal være 18, førend dette kort kan udstedes. Dette kort kan gå i overtræk og man kan hæve op til 25.000 kr. på dette kort om måneden";
        }


    }
}
