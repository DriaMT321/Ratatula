using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChefList
{
    public partial class ListaPedido : UserControl
    {
        private SocketManager _socketManager;
        private ObservableCollection<Pedido> _dataList;
        private bool _isSelectionEnabled = true;  // Variable de estado

        public ListaPedido(SocketManager socketManager)
        {
            InitializeComponent();
            _dataList = new ObservableCollection<Pedido>();
            DataContext = new MainViewModel { DataList = _dataList };

            _socketManager = socketManager;
            _socketManager.PedidosDataReceived += ProcessReceivedData;

            // Enviar solicitud de pedidos actuales
            _socketManager.SendRequest("REQUEST_PEDIDOS");
        }

        private void ProcessReceivedData(Pedido[] pedidos)
        {
            //string weu = "";
            Application.Current.Dispatcher.Invoke(() =>
            {
                _dataList.Clear();
                foreach (var pedido in pedidos)
                {
                    _dataList.Add(pedido);
                    //weu += pedido.Estado;
                }
                
            });
            //MessageBox.Show(weu);
            //weu = "";
        }

        private async void DataListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_isSelectionEnabled)
                return;

            if (DataListBox.SelectedItem is Pedido selectedPedido)
            {
                // Deshabilitar la selección temporalmente
                _isSelectionEnabled = false;

                // Toggle Estado: En espera -> Preparandose -> Listo
                switch (selectedPedido.Estado)
                {
                    case "En espera":
                        selectedPedido.Estado = "Preparandose";
                        break;
                    case "Preparandose":
                        selectedPedido.Estado = "Listo";
                        break;
                    case "Listo":
                        selectedPedido.Estado = "En espera";
                        break;
                }

                // Reordenar la lista de pedidos
                var orderedList = _dataList.OrderBy(p => p.Estado == "Listo" ? 0 :
                                                        p.Estado == "Preparandose" ? 1 : 2).ToList();
                _dataList.Clear();
                foreach (var pedido in orderedList)
                {
                    _dataList.Add(pedido);
                }

                // Deselect the item
                DataListBox.SelectedItem = null;

                // Mostrar el mensaje de cooldown
                CooldownTextBlock.Text = "Espere 1 segundo...";

                // Esperar un segundo antes de enviar la lista actualizada
                await Task.Delay(1000);

                // Enviar la lista actualizada de pedidos al servidor
                var updatedPedidosArray = new Pedido[_dataList.Count];
                _dataList.CopyTo(updatedPedidosArray, 0);
                _socketManager.SendData(updatedPedidosArray, "ESTATE");

                // Limpiar el mensaje de cooldown
                CooldownTextBlock.Text = "";

                // Habilitar la selección nuevamente
                _isSelectionEnabled = true;
            }
        }   
    }
}
