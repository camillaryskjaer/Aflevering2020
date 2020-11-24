using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypt
{
    //gui class
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
        }

        //asks for specific string (can give it input and it will ask for that input from the user.
        public string GetStringOfX(string x)
        {
            Console.Write(x + ": ");
            return Console.ReadLine();
        }

        //displays options.
        public int Options()
        {
            Console.Clear();
            Console.WriteLine("1. Encrypt");
            Console.WriteLine("2. Decrypt");

            int input = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return input;
        }

        //error message
        public void NotAnOption()
        {
            Console.WriteLine("That is not an option");
            Console.ReadKey();
        }

    }
}
