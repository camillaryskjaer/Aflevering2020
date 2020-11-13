using System;
using System.Collections.Generic;
using System.Text;

namespace KodeRefactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();

        }

        public void Print(string s)
        {
            Console.WriteLine(s);
        }

        public string GetUrl()
        {
            Console.Write("Url: ");
            return Console.ReadLine();
        }

        public string GetDns()
        {
            Console.Write("Trace dns server: ");
            return Console.ReadLine();
        }

    }
}
