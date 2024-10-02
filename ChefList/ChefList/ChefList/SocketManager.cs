using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

namespace ChefList
{
    public class SocketManager
    {
        private TcpClient _clientSocket;
        private NetworkStream _stream;
        public event Action<Pedido[]> CancelDataReceived;
        public event Action<Pedido[]> PedidosDataReceived;
        public event Action<Comida[]> ComidasDataReceived;

        public void ConnectToServer(string ipAddress, int port)
        {
            try
            {
                _clientSocket = new TcpClient(ipAddress, port);
                Console.WriteLine("Connected to server.");

                _stream = _clientSocket.GetStream();

                var identificationMessage = "CHEF";
                var identificationBytes = Encoding.UTF8.GetBytes(identificationMessage);
                _stream.Write(identificationBytes, 0, identificationBytes.Length);

                Thread receiveThread = new Thread(ReceiveData);
                receiveThread.IsBackground = true;
                receiveThread.Start();

                var buffer = new byte[131072];

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to server: {ex.Message}");
            }
        }

        public void SendData<T>(T[] objects, string type)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(objects);
                var data = Encoding.UTF8.GetBytes($"{type}:{jsonData}");
                _stream.Write(data, 0, data.Length);
                Console.WriteLine($"{type} data sent to server.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending data: {ex.Message}");
            }
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
                Console.WriteLine($"Error sending request: {ex.Message}");
            }
        }

        private void ReceiveData()
        {
            var buffer = new byte[131072];  // Incrementa el tamaño del buffer

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
                        var receivedPedidos = JsonConvert.DeserializeObject<Pedido[]>(jsonData);
                        PedidosDataReceived?.Invoke(receivedPedidos);
                    }
                    else if (receivedData.StartsWith("COMIDA:"))
                    {
                        var jsonData = receivedData.Substring("COMIDA:".Length);
                        var receivedComidas = JsonConvert.DeserializeObject<Comida[]>(jsonData);
                        ComidasDataReceived?.Invoke(receivedComidas);
                    }
                    else if (receivedData.StartsWith("CANCELADO:"))
                    {
                        var jsonData = receivedData.Substring("CANCELADO:".Length);
                        var receivedComidas = JsonConvert.DeserializeObject<Pedido[]>(jsonData);
                        CancelDataReceived?.Invoke(receivedComidas);
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
