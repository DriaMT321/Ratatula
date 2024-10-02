using MesaCliente.Class;
using MesaCliente.Interface;
using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Menu = MesaCliente.Interface.Menu;

namespace MesaCliente
{
    public partial class MainWindow : Window
    {
        private SocketManager _socketManager;
        Home home;
        Menu menu;
        Pagar pagar;
        ListaPedidos pedido;

        public MainWindow()
        {
            InitializeComponent();
            _socketManager = new SocketManager();
            _socketManager.ConnectToServer();
            home = new Home(_socketManager);
            menu = new Menu(_socketManager);
            pagar = new Pagar(_socketManager);
            pedido = new ListaPedidos(_socketManager);

            MainContent.Content = home;
            UpdateButtonStyles(Homebtn);
            _socketManager.SendRequest("MENU");
        }

        private void Homebtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = home;
            UpdateButtonStyles(sender as Button);
        }

        private void Menubtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = menu;
            UpdateButtonStyles(sender as Button);
        }

        private void Pedidobtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = pedido;
            UpdateButtonStyles(sender as Button);
        }

        private void Pagarbtn_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = pagar;
            UpdateButtonStyles(sender as Button);
        }

        private void UpdateButtonStyles(Button activeButton)
        {
            foreach (var child in ((StackPanel)activeButton.Parent).Children)
            {
                if (child is Button button)
                {
                    button.Style = button == activeButton ? (Style)FindResource("SelectedButtonStyle") : (Style)FindResource("RoundedButtonStyle");
                }
            }
        }
    }
}