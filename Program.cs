using System.Net.Sockets;

namespace SocketReader {
    public class Program {
        public static void Main(string[] args) {
            for(int i=0;i<25565;i++) { Connect("127.0.0.1", "MEOW", i); }  
        }
        static void Connect(String server, String message, int port) {
            try {
                TcpClient client = new(server, port);
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);
                data = new Byte[256];
                String responseData = String.Empty;
                int bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
                stream.Close();
                client.Close();
            }
            catch(ArgumentNullException e) {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch(SocketException e) {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
    }
}

