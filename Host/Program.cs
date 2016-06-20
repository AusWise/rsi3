using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost mojHost = new ServiceHost(typeof(Canvas));

            Uri baseAdress = new Uri("http://localhost:1014/Canvas2");
            Uri baseAdress2 = new Uri("http://localhost:2014");
            Uri baseAdress3 = new Uri("net.tcp://localhost:3014/SerwisTCP");

            mojHost.AddServiceEndpoint(typeof(ICanvas), new WSHttpBinding(), baseAdress);
            mojHost.AddServiceEndpoint(typeof(ICanvas), new WSHttpBinding(), baseAdress2);
            mojHost.AddServiceEndpoint(typeof(ICanvas), new NetTcpBinding(), baseAdress3);

            try
            {
                mojHost.Open();
                Console.WriteLine("Nacisnij <ENTER> aby zakonczyc.");
                Console.WriteLine();
                Console.ReadLine();
                mojHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Wystapil wyjatek: {0}", ce.Message);
                mojHost.Abort();
            }
        }
    }
}
