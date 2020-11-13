using System;
using System.Collections.Generic;
using System.Text;

namespace KodeRefactoring
{
    public class Controller
    {
        Program gui = new Program();
        public Controller()
        {
            DNS dns = new DNS();
            DHCP dhcp = new DHCP();
            Local local = new Local();


            gui.Print(dns.GetAddress(gui.GetUrl()));
            gui.Print(dns.Trace(gui.GetDns()));
            gui.Print(dhcp.DisplayDhcpServerAddresses());
            gui.Print(local.LocalPing());


            Console.ReadKey();
        }
    }
}
