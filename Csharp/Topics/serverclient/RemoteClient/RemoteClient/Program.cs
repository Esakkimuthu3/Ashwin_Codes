using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using RemoteServer;

namespace RemoteClient
{
    class Program
    {
        class tcpclient
        {
            static void Main(string[] args)
            {
                TcpChannel tc = new TcpChannel();
                ChannelServices.RegisterChannel(tc);
                service Service = (service)Activator.GetObject(typeof(service),"tcp://localhost:8089/ourfirstremoteservice");
                Console.WriteLine(Service.helloNigga("hellow remote"));
                Console.WriteLine(Service.highestnumber(20, 24));
                Console.ReadLine();

            }
        }
    }
}