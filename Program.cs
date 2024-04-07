using System.Net.Sockets;
using System.Text;

namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string defaultGateway = "192.168.100.3";
                int port = 80;

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                socket.Connect(defaultGateway, port);

                string getRequest = "GET / HTTP/1.1\r\nHost: " + defaultGateway + "\r\nConnection: Close\r\n\r\n";
                byte[] requestData = Encoding.ASCII.GetBytes(getRequest);

                socket.Send(requestData);

                byte[] buffer = new byte[1024];
                int received = socket.Receive(buffer);
                Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, received));

                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
