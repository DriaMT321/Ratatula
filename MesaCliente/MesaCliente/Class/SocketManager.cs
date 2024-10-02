using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MesaCliente.Class
{
    public class SocketManager
    {
        private TcpClient _clientSocket;
        private NetworkStream _stream;
        public event Action<Pedido[]> PedidoReceived;
        public event Action<Comida[]> MenuReceived;

        public void ConnectToServer()
        {
            _clientSocket = new TcpClient("127.0.0.1", 5000);
            Console.WriteLine("Connected to server.");
            
            _stream = _clientSocket.GetStream();

            var identificationMessage = "MESA";
            var identificationBytes = Encoding.UTF8.GetBytes(identificationMessage);
            _stream.Write(identificationBytes, 0, identificationBytes.Length);

            Thread receiveThread = new Thread(ReceiveData);
            receiveThread.IsBackground = true;
            receiveThread.Start();

            var buffer = new byte[131072];

            var receivedBytes = _stream.Read(buffer, 0, buffer.Length); 
            var clientNumberMessage = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
            if (clientNumberMessage.StartsWith("CLIENT_NUMBER:"))
            {
                int nMesa=int.Parse(clientNumberMessage.Substring("CLIENT_NUMBER:".Length));
                PedidosManager.Instance.NumeroDeMesa = nMesa;
            }
        }

        public void SendPedido(Pedido[] objects)
        {
            var jsonData = JsonConvert.SerializeObject(objects);
            var messageToSend = $"PEDIDO:{jsonData}";
            var data = Encoding.UTF8.GetBytes(messageToSend);
            _stream.Write(data, 0, data.Length);
            Console.WriteLine("Array sent to server.");
        }

        public void SendRequest(string requestType)
        {
            try
            {
                var data = Encoding.UTF8.GetBytes(requestType);
                _stream.Write(data, 0, data.Length);
                Console.WriteLine($"{requestType} request sent to server.");
            }
            catch (Exception ex)
            {
            }
        }
        private void ReceiveData()
        {
            var buffer = new byte[131072];

            while (true)
            {
                try
                {
                    var receivedBytes = _stream.Read(buffer, 0, buffer.Length);
                    if (receivedBytes == 0)
                    {
                        Console.WriteLine("Disconnected from server.");
                        _clientSocket.Close();
                        break;
                    }

                    var receivedData = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
                    if (receivedData.StartsWith("PEDIDO:"))
                    {
                        var jsonData = receivedData.Substring("PEDIDO:".Length);
                        var receivedObjects = JsonConvert.DeserializeObject<Pedido[]>(jsonData);
                        PedidoReceived?.Invoke(receivedObjects);
                    }
                    if (receivedData.StartsWith("COMIDA:"))
                    {
                        var jsonData = receivedData.Substring("COMIDA:".Length);
                        var receivedObjects = JsonConvert.DeserializeObject<Comida[]>(jsonData);
                        MenuReceived?.Invoke(receivedObjects);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Disconnected from server: {ex.Message}");
                    _clientSocket.Close();
                    break;
                }
            }
        }
    }
}
