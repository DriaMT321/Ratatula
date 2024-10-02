using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChefList
{
    /// <summary>
    /// Lógica de interacción para Facturas.xaml
    /// </summary>

    public partial class Facturas : UserControl
    {
        private SocketManager _socketManager;
        public Facturas(SocketManager socketManager)
        {
            InitializeComponent();
            _socketManager = socketManager;
            _socketManager.CancelDataReceived += OnCancelReceive;
        }
        private void OnCancelReceive(Pedido[] pedidos)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                FacturaListBox.ItemsSource = pedidos;
            });
        }
    }
}
