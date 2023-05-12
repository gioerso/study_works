using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab18_S_ISRPO
{
    internal class Program
    {
        public static int nClients = 0;
        const int ECHO_PORT = 8080;
        static void Main(string[] args)
        {
            try
            {
                TcpListener tcpListener = new TcpListener(ECHO_PORT);
                tcpListener.Start();
                Console.WriteLine("Wait");

                while (nClients < 3)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    ClientHandler cHandler = new ClientHandler();

                    cHandler.clientSocket = client;

                    Thread clientThread = new Thread(new ThreadStart(cHandler.RunClient));

                    clientThread.Start();
                    nClients++;
                }
                tcpListener.Stop();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ex: " + ex);
            }
        }
        public static string GetLocalIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters");
        }
    }
}
