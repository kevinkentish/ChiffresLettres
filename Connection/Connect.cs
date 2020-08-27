using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace Connection
{
    public class Connect
    {
        public static string ClientConnect(String word,int portid)
        {
        connection:
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", portid);
                // Console.Write("Enter Your name: ");
                //String Name = Console.ReadLine();

                string messageToSend = word;
                int byteCount = Encoding.ASCII.GetByteCount(messageToSend + 1);
                byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);

                NetworkStream stream = client.GetStream();
                stream.Write(sendData, 0, sendData.Length);
                //Console.WriteLine("sending data to server...");

                StreamReader sr = new StreamReader(stream);
                string response = sr.ReadLine();
                //Console.WriteLine(response);


                stream.Close();
                client.Close();
                return response;
                //Console.ReadKey();
            }
            catch (Exception e)
            {
                //Console.WriteLine("failed to connect...");

                goto connection;
                //return "failed to connect...";
            }
        }
    }
}
