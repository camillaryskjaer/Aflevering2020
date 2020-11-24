using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypt
{
    class Controller
    {
        public Controller()
        {
            //object references to the gui laye and encrpytion class .
            Program gui = new Program();
            Encryption encryption = new Encryption();

            //while loop constantly running to call the different methods the application has to offer.
            while (true)
            {
                //displays options and returns input
                int options = gui.Options();
                //if userinput is one, chose the first option
                if (options == 1)
                {
                    Console.Clear();

                    Console.WriteLine(encryption.Encrypt(gui.GetStringOfX("Message"), gui.GetStringOfX("Key")));

                    Console.ReadKey();
                }
                //if input is 3 chose the second option
                else if (options == 2)
                {
                    Console.Clear();

                    Console.WriteLine(encryption.Decrypt(gui.GetStringOfX("Encrypted Message"), gui.GetStringOfX("Key")));

                    Console.ReadKey();
                }
                //else there is an error.
                else
                {
                    gui.NotAnOption();
                }
            }
        }
    }
}
