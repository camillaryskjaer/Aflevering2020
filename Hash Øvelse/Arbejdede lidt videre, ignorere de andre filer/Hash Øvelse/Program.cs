using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Hash_Øvelse
{
    class Program
    {
        static RandomNumberGenerator random = RandomNumberGenerator.Create();
        static HMAC myMac;
        static void Main(string[] args)
        {
            //Choose hashing algorithm
            Console.WriteLine("What algorithme would you like to use?");
            Console.WriteLine("MD5 : SHA1 : SHA256 : SHA384 : SHA512");
            //updates myMac to be equal to the algorithm the user has input, if there's a type or none is selected, then SHA1 will be used by default.
            MACHandler(Console.ReadLine());
            Console.Clear();

            //Get input message text
            Console.WriteLine("Enter the message your would like to hash");
            string message = Console.ReadLine();
            Console.Clear();


            //--Get input key--
            //Converts useinput to byte array, and sets the myMac.key to that value. 
            Console.WriteLine("Enter your key (Type 'random' for a random key)");
            //stores key in a string
            string key = Console.ReadLine();
            if(key == "random")
            {
                random.GetBytes(myMac.Key);
                key = System.Text.Encoding.ASCII.GetString(myMac.Key, 0, myMac.Key.Length);
            }
            //Converts key to bytearray and assigns myMac.key the value of the key input by the user.
            myMac.Key = Encoding.ASCII.GetBytes(key);
            Console.Clear();


            //Print algorithm used
            Console.WriteLine("Algorithm: {0}", myMac.HashName);

            //Print Plain text
            Console.WriteLine("\nPlain text: \"{0}\"", message);

            //Prints key
            Console.WriteLine("\nKey: {0}", key);


            //Print hashed message with time of hashing
            byte[] byteMessage = Encoding.ASCII.GetBytes(message);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            byte[] hashedmessage = myMac.ComputeHash(byteMessage);
            stopWatch.Stop();
            TimeSpan timeSpan = stopWatch.Elapsed;
            string hashedString = BitConverter.ToString(hashedmessage, 0);
            hashedString = hashedString.Replace("-", "");
            Console.WriteLine("\nMac: {0}", hashedString);

            //ComputerHash timer
            string time = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
            Console.WriteLine("\nDuration of hashing: {0}", time);


            Console.ReadKey();

        }

        //updates myMac to be equal to the algorithm the user has input, if there's a type or none is selected, then SHA1 will be used by default.
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

            //If input is wrong, SHA1 is used as default
            myMac = new System.Security.Cryptography.HMACSHA1();
        }
    }
}
