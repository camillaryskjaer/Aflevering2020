using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankeriii
{
    
    //Hvorfor er dette objekt ikke abstrakt?
    public class Card
    {
        //variblerne som går igen på alle kortene (ud over expirationDate men har valgt at lave et workaround rundt om det.
        protected string cardName;
        protected string cardNumber;
        protected DateTime expirationDate;
        protected string accountNumber;
        protected string name;

        public string CardName
        {
            get { return cardName; }
            protected set { cardName = value; }
        }
        public string CardNumber
        {
            get { return cardNumber; }
            protected set { cardNumber = value; }
        }
        public string AccountNumber
        {
            get { return accountNumber; }
            protected set { accountNumber = value; }
        }
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }
        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            protected set { expirationDate = value; }
        }

        //Constructer til at lave et kort for at undgå at skrive ting flere gange, den indeholder bare de værdier som går igen på de forskellige kort
        //CardName burde altid blive overskrevet
        //5år er den mest brugte expirationDate så den er med i skabelonen for at undgå at genskrive kode hvis kortet har en 5års expiration date.
        public Card(string name)
        {
            CardName = "Template";              
            AccountNumber = GenerateAccountNumber(14, "3250"); //14 = length. 3250 = prefix
            ExpirationDate = DateTime.Now.AddYears(5);
            Name = name;

        }

        //Generere account nummer, "prefix" parameteret er et tal som alle kontoer starter ud med og "TotalLength" er den total længe af account nummer incl prefix.
        public string GenerateAccountNumber(int TotalLength, string prefix)
        {
            Random random = new Random();
            
            //Pool af de chars som randomizeren tager af, det kan være at man ikke længere vil bruge 0 i sine kort, så kan det hurtigt ændres.
            string charPool = ("1234567890");
             
            //Definere længden på char arrayed.
            char[] stringChars = new char[TotalLength - prefix.Length];

            //Fylder char array
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = charPool[random.Next(charPool.Length)];
            }

            //Laver char arrayed til en string
            string finalString = new String(stringChars);

            //Adder prefix forand char arrayed of retunere string.
            return (prefix + finalString);
        }

        //Denne metode gør stort set det samme 
        //(Første brugte jeg den samme til begge ved bare at bruge string prefix fra den anden som et string array
        //med kun en string i men var bange for at det kunne ses som at være dogen)
        //Så det er bare den samme metode med den eneste foreskel at den tager et array af prefixes istedet for en enkel string som prefix.
        public string GenerateCardNumber(int TotalLength, string[] prefixes)
        {
            Random random = new Random();

            string prefix = prefixes[random.Next(0, prefixes.Count())];

            string charPool = ("1234567890");

            char[] stringChars = new char[TotalLength - prefix.Length];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = charPool[random.Next(charPool.Length)];
            }   

            string finalString = new String(stringChars);

            return (prefix + finalString);

        }

        //Fint med override af toString
        //To String method med alt informationen på kortene, og hvis kortets expiration date er over år 3000, så udskriver den
        //"No expiration date".
        public override string ToString()
        {
            string expiration = "";
            DateTime futureDate = new DateTime(3000, 1, 1);
            if (Convert.ToDateTime(ExpirationDate) > futureDate)
            {
                expiration = "No expiration date";
            }
            else
            {
                expiration = ExpirationDate.ToString();
            }

            return
                "Card type: " + CardName + "\n" +
                "Card Number: " + CardNumber + "\n" +
                "Account Number: " + AccountNumber + "\n" +
                "Exiration Date: " + expiration;
        }

    }
}
