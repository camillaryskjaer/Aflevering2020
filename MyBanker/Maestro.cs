using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankeriii
{
    class Maestro : Card
    {
        public Maestro(string name) : base(name)
        {
            CardName = "Maestro";
            ExpirationDate = DateTime.Now.AddYears(5).AddMonths(8);
            CardNumber = GenerateCardNumber(19, new string[] { "5018", "5020", "5038", "5893", "6304", "6759", "6761", "6762", "6763" });
        }

        public override string ToString()
        {
            return base.ToString() + "\nMaestrokortet er også et debetkort, men dette kan bruges internationalt og på Nettet. Man skal være 18 førend dette kort kan udstedes til kunden.";
        }
    }
}
