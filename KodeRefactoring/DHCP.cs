using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace KodeRefactoring
{
    public class DHCP
    {
        public string DisplayDhcpServerAddresses()
        {
            string print = "DHCP Servers\n";
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapteradapterProperties = adapter.GetIPProperties();
                IPAddressCollection addresses = adapteradapterProperties.DhcpServerAddresses;
                if (addresses.Count > 0)
                {
                    Console.WriteLine(adapter.Description);
                    foreach (IPAddress address in addresses)
                    {
                        print = print + $"  Dhcp Address ............................ : {address.ToString()}";
                    }
                    Console.WriteLine();
                }
            }

            return print;
        }
    }
}
