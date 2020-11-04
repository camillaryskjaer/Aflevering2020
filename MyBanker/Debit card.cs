using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankeriii
{
    class Debit_card : Card
    {
        public Debit_card(string name) : base(name)
        {
            CardName = "Debit card";
            ExpirationDate = DateTime.Now.AddYears(1000);
            CardNumber = GenerateCardNumber(16, new string[] { "2400" });
        }

        public override string ToString()
        {
            return base.ToString() + "\nDette kort tilbydes primært til kunder under 18 år og til kunder som ikke opfylder kriterierne for VISA, Maestro eller Mastercard. Kortet er et debetkort, hvilket betyder at pengene trækkes med det samme fra kontoen og der kan ikke laves et overtræk";
        }
    }
}
