using System.Windows;
using System.Windows.Controls;

namespace ChefList
{
    public partial class MainWindow : Window
    {
        private ListaPedido listaPedido;
        private MenuManagement menuManagement;
        private SocketManager _socketManager;
        private Facturas factos;

        public MainWindow()
        {
            InitializeComponent();
            _socketManager = new SocketManager();
            _socketManager.ConnectToServer("127.0.0.1", 5000);
            listaPedido = new ListaPedido(_socketManager);
            menuManagement = new MenuManagement(_socketManager);
            factos = new Facturas(_socketManager);
            UpdateButtonStyles(Pedidosbtn);
            MainContent.Content = listaPedido;
        }

        private void Pedidos_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = listaPedido;
            UpdateButtonStyles(sender as Button);
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = menuManagement;
            UpdateButtonStyles(sender as Button);
        }

        private void Cancelado_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = factos;
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
