using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerUDP
{
    class Program
    {
        //Kommentar geschrieben
        private const int listenPort = 11000;
        public static int Main()
        {
            DateTime date = new DateTime();
            bool done = false;
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            string received_data;
            byte[] receive_byte_array;
            try
            {
                Console.WriteLine("Waiting for broadcast");
                receive_byte_array = listener.Receive(ref groupEP);
                Console.WriteLine("Received a broadcast from {0}", groupEP.ToString());
                received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
                date = DateTime.Parse(received_data);
                Console.WriteLine("received Date: {0}\n", date);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            listener.Close();
            Console.ReadLine();
            return 0;
        }
    }
}
