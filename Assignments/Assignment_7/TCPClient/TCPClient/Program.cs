using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using TCPServer;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TcpChan tcpChannel = new TcpChan(8002);
            ChannelServices.RegisterChannel(tcpChannel);
            Work work = (Work)Activator.GetObject(typeof(Work),
                "http://localhost:8089/OurFirstRemoteService");
            Console.WriteLine(work.SayHello("  Remote"));
            Console.WriteLine(work.HighestNumber(20, 25));
            Console.Read();
        }
    }
}