using System;
using System.Security.Cryptography;
using System.Text;

namespace Hash_Øvelse
{
    class Program
    {
        static HMAC myMac;
        static void Main(string[] args)
        {
            //Get message text
            Console.WriteLine("Enter the message your would like to hash");
            string message = Console.ReadLine();
            Console.Clear();

            //Choose hashing algorithm
            Console.WriteLine("What algorithme would you like to use?");
            Console.WriteLine("MD5 : SHA1 : SHA256 : SHA384 : SHA512");
            MACHandler(Console.ReadLine());
            Console.Clear();

            //Print Plain text
            Console.WriteLine("Plain text: \"{0}\"", message);

            //Prints key
            string key = BitConverter.ToString(myMac.Key, 0);
            key = key.Replace("-",""); 
            Console.WriteLine("\nKey: {0}", key);

            //Mac in Ascii
            byte[] asciiMessage = Encoding.ASCII.GetBytes(message);
            string asciiString = BitConverter.ToString(asciiMessage, 0);
            asciiString = asciiString.Replace("-", "");
            Console.WriteLine("\nMac: {0}", asciiString);

            

            Console.ReadKey();

        }
        
        static public void MACHandler(string name)
        {
            if(name == "MD5")
            {
                myMac = new System.Security.Cryptography.HMACMD5();
            }
            if (name == "SHA1")
            {
                myMac = new System.Security.Cryptography.HMACSHA1();
            }
            if (name == "SHA256")
            {
                myMac = new System.Security.Cryptography.HMACSHA256();
            }
            if (name == "SHA384")
            {
                myMac = new System.Security.Cryptography.HMACSHA384();
            }
            if (name == "SHA512")
            {
                myMac = new System.Security.Cryptography.HMACSHA512();
            }
        }
    }
}
