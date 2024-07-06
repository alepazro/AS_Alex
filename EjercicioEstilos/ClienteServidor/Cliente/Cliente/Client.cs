using System;
using System.Net.Sockets;
using System.Text;

namespace Cliente
{
    public class Cliente
    {
        public static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient("localhost", 12345); // Dirección IP del servidor y puerto

                Console.WriteLine("Conectado al servidor.");

                NetworkStream stream = client.GetStream();

                // Envía mensajes al servidor
                string message = "Hola, servidor!";
                byte[] dataToSend = Encoding.ASCII.GetBytes(message);
                stream.Write(dataToSend, 0, dataToSend.Length);

                // Recibe la respuesta del servidor
                byte[] dataReceived = new byte[4096];
                int bytesRead = stream.Read(dataReceived, 0, 4096);
                string response = Encoding.ASCII.GetString(dataReceived, 0, bytesRead);
                Console.WriteLine("Respuesta del servidor: " + response);

                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
