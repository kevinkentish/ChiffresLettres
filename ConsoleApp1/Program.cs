using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 1302);
            //TcpListener listener2 = new TcpListener(System.Net.IPAddress.Any, 1303);
            listener.Start();
            //listener2.Start();
            while (true)
            {
                Console.WriteLine("Waiting for a connection.");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
                Console.WriteLine("Client accepted.");
                NetworkStream stream = client.GetStream();
                StreamReader sr = new StreamReader(client.GetStream());
                StreamWriter sw = new StreamWriter(client.GetStream());
                try
                {
                    byte[] buffer = new byte[1024];
                    stream.Read(buffer, 0, buffer.Length);
                    int recv = 0;
                    foreach (byte b in buffer)
                    {
                        if (b != 0)
                        {
                            recv++;
                        }
                    }
                    string request = Encoding.UTF8.GetString(buffer, 0, recv);

                    List<string> words = LoadWords.LoadWordsList();
                    bool found = CheckWord.CheckExistingWord(request);

                    Console.WriteLine(found.ToString());
                    sw.WriteLine(found.ToString());
                    sw.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong.");
                    //sw.WriteLine(e.ToString());
                }
            }
        }
    }
}
