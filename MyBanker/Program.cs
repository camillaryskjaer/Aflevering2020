using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankeriii
{
    class Program
    {
        static void Main(string[] args)
        {
            //Det eneste input der er brug for når objecterne bliver initilized er navnet på korholderen.
            Card mastercard = new Mastercard("mads stasel");
            Card visa_dankort = new VISA_Dankort("mads stasel");
            Card visa_electron = new VISA_Electron("mads stasel");
            Card maestro = new Maestro("mads stasel");
            Card debit_card = new Debit_card("mads stasel");

            //Samler alle kortene i en liste så jeg hurtigt kan printe dem ud for nemt debugge.
            List<Card> cards = new List<Card>();
            cards.Add(mastercard);
            cards.Add(visa_dankort);
            cards.Add(visa_electron);
            cards.Add(debit_card);
            cards.Add(maestro);
            for (int i = 0; i < cards.Count; i++)
            {
                Console.WriteLine(cards[i].ToString());
                Console.WriteLine();
            }
               
            

            Console.ReadKey();
            
        }
    }
}
