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
    class Local
    {
        public string LocalPing()
        {
            string info = "";
            // Ping's the local machine.
            Ping pingSender = new Ping();
            IPAddress address = IPAddress.Loopback;
            PingReply reply = pingSender.Send(address);

            if (reply.Status == IPStatus.Success)
            {
                info = $"\nLocalInfomation:\nAddress: {reply.Address.ToString()}\n" +
                        $"RoundTrip time: {reply.RoundtripTime}\n" +
                        $"Time to live: {reply.Options.Ttl}\n" +
                        $"Don't fragment: {reply.Options.DontFragment}\n" +
                        $"Buffer size: {reply.Buffer.Length}\n";
            }
            else
            {
                info = reply.Status.ToString();
            }

            return info;
        }
    }
}
