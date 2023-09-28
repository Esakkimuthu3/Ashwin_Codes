using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;

namespace RemoteServer
{
    public class remoteobjectserver
    {
        public remoteobjectserver()
        {

        }
    }
    public class service : MarshalByRefObject
    {
        public string helloNigga(string s)
        {
            return "hello" + " " + s;
        }

        public int highestnumber(int x, int y)
        {
            int maxnumber = Math.Max(x, y);
            return maxnumber;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel t = new TcpChannel(8089);
            ChannelServices.RegisterChannel(t);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(service), "ourfirstremoteservice", WellKnownObjectMode.Singleton);
            Console.WriteLine("server services started at port number 8089");
            Console.WriteLine("press any key to stop the server services");
            Console.ReadLine();
        }
    }
}