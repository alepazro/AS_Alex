using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Servidor
{
    public class Servidor
    {
        private TcpListener tcpListener;
        private Thread listenerThread;

        public Servidor()
        {
            this.tcpListener = new TcpListener(IPAddress.Any, 12345); // Puerto en el que el servidor espera conexiones
            this.listenerThread = new Thread(new ThreadStart(ListenForClients));
            this.listenerThread.Start();
        }

        private void ListenForClients()
        {
            this.tcpListener.Start();

            Console.WriteLine("Servidor esperando conexiones...");

            while (true)
            {
                TcpClient client = this.tcpListener.AcceptTcpClient(); // Espera a que un cliente se conecte

                Console.WriteLine("Cliente conectado.");

                // Crea un hilo para manejar la comunicación con el cliente
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object clientObj)
        {
            TcpClient client = (TcpClient)clientObj;
            NetworkStream clientStream = client.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    // Lee los datos del cliente
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }

                if (bytesRead == 0)
                {
                    // Cliente desconectado
                    break;
                }

                // Decodifica los datos recibidos
                string dataReceived = Encoding.ASCII.GetString(message, 0, bytesRead);
                Console.WriteLine("Mensaje del cliente: " + dataReceived);

                // Envía una respuesta al cliente
                byte[] response = Encoding.ASCII.GetBytes("Respuesta desde el servidor: " + dataReceived);
                clientStream.Write(response, 0, response.Length);
                clientStream.Flush(); // Asegura que se envíen todos los datos
            }

            client.Close();
        }

        public static void Main(string[] args)
        {
            Servidor server = new Servidor();
        }
    }

}
