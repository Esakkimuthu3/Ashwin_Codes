using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using TCPServer;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            
             TcpChannel tcpChannel = new TcpChannel(8002);
            ChannelServices.RegisterChannel(tcpChannel);
           Service work = (Service)Activator.GetObject(typeof(Service),
                "http://localhost:8089/OurFirstRemoteService");
            Console.WriteLine(work.SayHello("  Remote"));
            Console.WriteLine(work.HighestNumber(20, 25));
            Console.Read();
        }
    }
}