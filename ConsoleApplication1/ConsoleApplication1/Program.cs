using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string data; // Юзерская дата
            byte[] remdata = { };
            TcpClient Client = new TcpClient();
            Console.Write("IP to connect to: ");
            string ip = Console.ReadLine();
            Console.Write("\r\nPort: ");
            int port = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\r\nConnecting to server...");
            try
            {
                Client.Connect(ip, port);
            }
            catch
            {
                Console.WriteLine("Cannot connect to remote host!");
                return;
            }
            Console.Write("done\r\nTo end, type 'END'");
            Socket Sock = Client.Client;
            while (true)
            {
                Console.Write("\r\n>");
                data = Console.ReadLine();
                if (data == "END")
                    break;
                Sock.Send(Encoding.ASCII.GetBytes(data));
                Sock.Receive(remdata);
                Console.Write("\r\n<" + Encoding.ASCII.GetString(remdata));
            }
            Sock.Close();
            Client.Close();
        }
    }
}
