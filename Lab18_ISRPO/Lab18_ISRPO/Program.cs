using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lab18_ISRPO
{
    internal class Program
    {
        const int ECHO_PORT = 8080;
        static void Main(string[] args)
        {
            Console.WriteLine("Your Name?:");
            string name = Console.ReadLine();
            Console.WriteLine("Logged in");

            try
            {
                TcpClient tcpClient = new TcpClient("127.0.0.1", ECHO_PORT);
                StreamReader rs = new StreamReader(tcpClient.GetStream());
                NetworkStream ns = tcpClient.GetStream();

                string dataToSend;
                dataToSend = name;
                dataToSend += "\r\n";

                byte[] data = Encoding.UTF8.GetBytes(dataToSend);
                ns.Write(data, 0, data.Length);


                while (true)
                {
                    Console.Write(name + ":");
                    dataToSend = Console.ReadLine();
                    dataToSend += "\r\n";

                    data = Encoding.UTF8.GetBytes(dataToSend);
                    ns.Write(data, 0, data.Length);

                    if (dataToSend.IndexOf("QUIT") > -1) break;

                    string returnData;
                    returnData = rs.ReadLine();
                    Console.WriteLine("Server: " + returnData);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ex: " + ex.Message);
            }
        }
    }
}
