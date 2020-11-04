using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankeriii
{
    class Mastercard : Card
    {

        public Mastercard(string name) : base(name)
        {
            CardName = "Mastercard";
            CardNumber = GenerateCardNumber(16, new string[] { "51", "52", "53", "54", "55" });
        }

        public override string ToString()
        {
            return base.ToString() + "\nMastercard er et kreditkort, som tilbyder en kredit på op til 40.000 kr. om måneden. Saldoen opgøres en gang om måneden og kunden betaler sit udestående. Man kan hæve op til 5000 kr. om dagen på dette kort og op til 30.000 om måneden.";
        }

    }
}
