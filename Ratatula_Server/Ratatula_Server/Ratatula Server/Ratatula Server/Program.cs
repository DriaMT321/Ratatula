using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace SocketServer
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NombreComida { get; set; }
        public int Mesa { get; set; }
        public string Estado { get; set; }
        public DateTime FechaHora { get; set; }
        public double Precio { get; set; }
    }

    public class Comida
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Categoria { get; set; }
    }

    class Program
    {
        static List<Pedido> cancelados = new List<Pedido>();
        static List<Socket> chefs = new List<Socket>();
        static List<Socket> clients = new List<Socket>();
        static int clientMesa = 1;
        static int clientChef = 100;
        static Dictionary<Socket, int> clientNumbers = new Dictionary<Socket, int>();
        static List<Pedido> pedidos = new List<Pedido>();
        static List<Comida> comidas = new List<Comida>();
        const string menuFilePath = "menu.json";
        const string canceladosFilePath = "cancelado.json";

        static void Main(string[] args)
        {
            InitializeFiles();
            LoadMenu();
            LoadCancelados();

            var listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();
            Console.WriteLine("Servidor Iniciado.");

            while (true)
            {
                var clientSocket = listener.AcceptSocket();
                var clientThread = new Thread(() => HandleClient(clientSocket));
                clientThread.Start();
            }
        }

        static void InitializeFiles()
        {
            if (!File.Exists(menuFilePath))
            {
                File.WriteAllText(menuFilePath, JsonConvert.SerializeObject(comidas));
            }

            if (!File.Exists(canceladosFilePath))
            {
                File.WriteAllText(canceladosFilePath, JsonConvert.SerializeObject(cancelados));
            }
        }

        static void LoadMenu()
        {
            if (File.Exists(menuFilePath))
            {
                var menuJson = File.ReadAllText(menuFilePath);
                comidas = JsonConvert.DeserializeObject<List<Comida>>(menuJson);
            }
        }

        static void SaveMenu()
        {
            var menuJson = JsonConvert.SerializeObject(comidas, Formatting.Indented);
            File.WriteAllText(menuFilePath, menuJson);
        }

        static void LoadCancelados()
        {
            if (File.Exists(canceladosFilePath))
            {
                var canceladosJson = File.ReadAllText(canceladosFilePath);
                cancelados = JsonConvert.DeserializeObject<List<Pedido>>(canceladosJson);
            }
        }

        static void SaveCancelados()
        {
            var canceladosJson = JsonConvert.SerializeObject(cancelados, Formatting.Indented);
            File.WriteAllText(canceladosFilePath, canceladosJson);
        }

        static void HandleClient(object obj)
        {
            var clientSocket = (Socket)obj;
            var buffer = new byte[131072];  // Incrementa el tamaño del buffer

            // Identificar el tipo de cliente
            string clientType = IdentifyClient(clientSocket);
            if (clientType == "CHEF")
            {
                lock (chefs)
                {
                    chefs.Add(clientSocket);
                    lock (clientNumbers)
                    {
                        clientNumbers[clientSocket] = clientChef;
                        clientChef++;
                    }
                }
            }
            else if (clientType == "MESA")
            {
                lock (clients)
                {
                    clients.Add(clientSocket);
                    lock (clientNumbers)
                    {
                        clientNumbers[clientSocket] = clientMesa;
                        clientMesa++;
                    }
                }
            }

            // Enviar el número de cliente a las mesas
            if (clientType == "MESA")
            {
                var clientNumber = clientNumbers[clientSocket];
                var clientNumberMessage = $"CLIENT_NUMBER:{clientNumber}";
                clientSocket.Send(Encoding.UTF8.GetBytes(clientNumberMessage));
            }

            while (true)
            {
                try
                {
                    var receivedBytes = clientSocket.Receive(buffer);
                    if (receivedBytes == 0)
                    {
                        lock (clients) { clients.Remove(clientSocket); }
                        clientSocket.Close();
                        Console.WriteLine($"{clientType} {clientNumbers[clientSocket]} desconectado.");
                        break;
                    }

                    var receivedData = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
                    Console.WriteLine($"Cliente {clientType} {clientNumbers[clientSocket]} data: {receivedData}");


                    if (receivedData.StartsWith("MENU"))
                    {
                        SendComidasToClient(clientSocket);
                    }
                    
                    if (receivedData.StartsWith("REQUEST_PEDIDOS"))
                    {
                        SendPedidosToClient(clientSocket,clientType);
                        Thread.Sleep(500);
                        SendCanceladosToChef();
                    }
                    
                    if (receivedData.StartsWith("ESTATE:"))
                    {
                        var jsonString = receivedData.Substring("ESTATE:".Length);
                        var pedidos = JsonConvert.DeserializeObject<Pedido[]>(jsonString);

                        lock (Program.pedidos)
                        {
                            Program.pedidos.Clear();
                            Program.pedidos.AddRange(pedidos);
                            SendPedidosToAllClients();
                        }
                    }
                    if (receivedData.StartsWith("PEDIDO:"))
                    {
                        var jsonString = receivedData.Substring("PEDIDO:".Length);
                        var pedidos = JsonConvert.DeserializeObject<Pedido[]>(jsonString);

                        lock (Program.pedidos)
                        {
                            Program.pedidos.AddRange(pedidos);
                            SendPedidoToChef();
                            SendPedidosToClient(clientSocket, clientType);
                        }
                    }

                    //Modifica el menu y lo actualiza en todos los clientes
                    else if (receivedData.StartsWith("COMIDA:"))
                    {
                        var jsonString = receivedData.Substring("COMIDA:".Length);
                        var updatedComidas = JsonConvert.DeserializeObject<List<Comida>>(jsonString);

                        lock (Program.comidas)
                        {
                            Program.comidas = updatedComidas;
                            SaveMenu();
                            SendComidasToAllClients();
                        }
                    }
                    if (receivedData.StartsWith("END_SERVICE"))
                    {
                        var pedidosMesa = pedidos.Where(p => p.Mesa == clientNumbers[clientSocket]).ToList();
                        cancelados.AddRange(pedidosMesa);
                        pedidos.RemoveAll(p => p.Mesa == clientNumbers[clientSocket]);
                        SaveCancelados();
                        SendPedidosToAllClients();
                        Thread.Sleep(500);
                        SendCanceladosToChef();
                        Thread.Sleep(500);
                        Console.WriteLine($"Pedidos de la mesa {clientNumbers[clientSocket]} cancelados y movidos a la lista de cancelados.");
                    }
                    if (receivedData.StartsWith("CANCEL"))
                    {
                        SendCanceladosToChef();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Client {clientType} {clientNumbers[clientSocket]} disconnected: {ex.Message}");
                    lock (clients) { clients.Remove(clientSocket); }
                    clientSocket.Close();
                    break;
                }
            }
        }
        static void SendCanceladosToChef()
        {
            var cancelJson = JsonConvert.SerializeObject(cancelados);
            var updateCancelado = $"CANCELADO:{cancelJson}";
            var messageBytes = Encoding.UTF8.GetBytes(updateCancelado);
            lock (chefs)
            {
                foreach (var chef in chefs)
                {
                    try
                    {
                        chef.Send(messageBytes);
                        Thread.Sleep(500);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error sending to client: {ex.Message}");
                    }
                }
            }
        }

        static void SendPedidoToChef()
        {
            var updatedComidasJson = JsonConvert.SerializeObject(pedidos);
            var updatedComidasMessage = $"PEDIDO:{updatedComidasJson}";
            var messageBytes = Encoding.UTF8.GetBytes(updatedComidasMessage);
            lock (chefs)
            {
                foreach (var chef in chefs)
                {
                    try
                    {
                        chef.Send(messageBytes);
                        Thread.Sleep(500);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error sending to client: {ex.Message}");
                    }
                }
            }
        }
        static string IdentifyClient(Socket clientSocket)
        {
            var buffer = new byte[4096];
            var receivedBytes = clientSocket.Receive(buffer);
            var receivedData = Encoding.UTF8.GetString(buffer, 0, receivedBytes);

            if (receivedData.StartsWith("CHEF"))
            {
                return "CHEF";
            }
            else if (receivedData.StartsWith("MESA"))
            {
                return "MESA";
            }
            return "UNKNOWN";
        }

        static void SendPedidosToAllClients()
        {
            var updatedPedidosJson = JsonConvert.SerializeObject(pedidos);
            var updatedPedidosMessage = $"PEDIDO:{updatedPedidosJson}";
            var messageBytes = Encoding.UTF8.GetBytes(updatedPedidosMessage);

            lock (chefs)
            { 
                foreach(var chef in chefs)
                {
                    try
                    {
                        Console.WriteLine("Enviado a chef");
                        var jsonlinq = JsonConvert.SerializeObject(pedidos);
                        var response = $"PEDIDO:{jsonlinq}";
                        chef.Send(Encoding.UTF8.GetBytes(response));
                        Thread.Sleep(500);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error sending to client: {ex.Message}");
                    }
                }
            } 

            lock (clients)
            {
                foreach (var client in clients)
                {
                    try
                    {
                        var query = pedidos.Where(p => p.Mesa == clientNumbers[client]).ToList();
                            Console.WriteLine($"Enviado a mesa {clientNumbers[client]}");
                            var jsonlinq = JsonConvert.SerializeObject(query);
                            var response = $"PEDIDO:{jsonlinq}";
                            client.Send(Encoding.UTF8.GetBytes(response));
                            Thread.Sleep(500);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error sending to client: {ex.Message}");
                    }
                }
            }
        }

        static void SendPedidosToClient(Socket clientSocket, string type)
        {
            List<Pedido> query = pedidos;
            if(type=="MESA")
                query = pedidos.Where(p => p.Mesa == clientNumbers[clientSocket]).ToList();
            var updatedPedidosJson = JsonConvert.SerializeObject(query);
            var updatedPedidosMessage = $"PEDIDO:{updatedPedidosJson}";
            var messageBytes = Encoding.UTF8.GetBytes(updatedPedidosMessage);

            try
            {
                clientSocket.Send(messageBytes);
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending to client: {ex.Message}");
            }
        }

        static void SendComidasToAllClients()
        {
            var updatedComidasJson = JsonConvert.SerializeObject(comidas);
            var updatedComidasMessage = $"COMIDA:{updatedComidasJson}";
            var messageBytes = Encoding.UTF8.GetBytes(updatedComidasMessage);
            lock (chefs)
            {
                foreach (var chef in chefs)
                {
                    try
                    {
                        chef.Send(messageBytes);
                        Thread.Sleep(500);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error sending to client: {ex.Message}");
                    }
                }
            }
            lock (clients)
            {
                foreach (var client in clients)
                {
                    try
                    {
                        client.Send(messageBytes);
                        Thread.Sleep(500);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error sending to client: {ex.Message}");
                    }
                }
            }
        }

        static void SendComidasToClient(Socket clientSocket)
        {
            var updatedComidasJson = JsonConvert.SerializeObject(comidas);
            var updatedComidasMessage = $"COMIDA:{updatedComidasJson}";
            var messageBytes = Encoding.UTF8.GetBytes(updatedComidasMessage);

            try
            {
                clientSocket.Send(messageBytes);
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending to client: {ex.Message}");
            }
        }
    }
}
