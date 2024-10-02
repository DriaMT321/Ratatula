using MesaCliente.Class;
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

namespace MesaCliente.Interface
{
    /// <summary>
    /// Lógica de interacción para ListaPedidos.xaml
    /// </summary>
    public partial class ListaPedidos : UserControl
    {
        private SocketManager _socketManager;
        public ListaPedidos(SocketManager socketManager)
        {
            InitializeComponent();
            _socketManager = socketManager;
            _socketManager.PedidoReceived += OnPedidoReceived;
            Loaded += Principal_Loaded;
        }
        private void Principal_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRightList();
        }
        private void LoadLeftList(Pedido[] pedidos)
        {
            // Ordenar los pedidos: primero "Listo", luego "Preparando", y finalmente "En espera"
            var sortedPedidos = pedidos.OrderBy(p => p.Estado == "Listo" ? 0 : p.Estado == "Preparando" ? 1 : 2).ToArray();

            double yPosition = 10;
            foreach (var item in sortedPedidos)
            {
                // Create the border with rounded corners
                var border = new Border
                {
                    Width = 300,
                    Height = 50,
                    Background = Brushes.White,
                    CornerRadius = new CornerRadius(10),
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1)
                };
                Canvas.SetLeft(border, 10);
                Canvas.SetTop(border, yPosition);

                // Create the Grid to hold the label and ellipse
                var grid = new Grid
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch
                };
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                // Create the label
                var label = new Label
                {
                    Content = item.NombreComida,
                    FontSize = 16,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                Grid.SetColumn(label, 0);
                grid.Children.Add(label);

                // Create the ellipse (circle) to indicate the status
                var ellipse = new Ellipse
                {
                    Width = 20,
                    Height = 20,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Margin = new Thickness(0, 0, 10, 0)
                };

                // Set the color of the ellipse based on the status
                switch (item.Estado)
                {
                    case "En espera":
                        ellipse.Fill = Brushes.Red;
                        break;
                    case "Preparandose":
                        ellipse.Fill = Brushes.Yellow;
                        break;
                    case "Listo":
                        ellipse.Fill = Brushes.Green;
                        break;
                    default:
                        ellipse.Fill = Brushes.Gray;
                        break;
                }

                Grid.SetColumn(ellipse, 1);
                grid.Children.Add(ellipse);

                // Add the Grid to the Border
                border.Child = grid;

                // Add the Border to the Canvas
                leftCanvas.Children.Add(border);

                yPosition += 60;
            }

            // Ajusta la altura del Canvas al contenido
            leftCanvas.Height = yPosition + 10;
        }

        private void LoadRightList()
        {
            double yPosition = 10;
            foreach (var item in PedidosManager.Instance.GetPedidos())
            {
                // Create the border with rounded corners
                var border = new Border
                {
                    Width = 180,
                    Height = 50,
                    Background = Brushes.White,
                    CornerRadius = new CornerRadius(10),
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1)
                };
                Canvas.SetLeft(border, 10);
                Canvas.SetTop(border, yPosition);

                // Create the Grid to hold the label and button
                var grid = new Grid
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch
                };
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                // Create the label
                var label = new Label
                {
                    Content = item.NombreComida,
                    FontSize = 16,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                Grid.SetColumn(label, 0);
                grid.Children.Add(label);

                // Create the button (circular with 'X')
                var button = new Button
                {
                    Tag = item,
                    Content = "X",
                    Width = 20,
                    Height = 20,
                    Style = (Style)FindResource("CircularButtonStyle"), // Assuming the style is defined in Application resources
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Margin = new Thickness(0, 5, 5, 0)
                };
                button.Click += (s, e) =>
                {

                    PedidosManager.Instance.quitar(item);
                    rightCanvas.Children.Clear();
                    LoadRightList();
                };
                Grid.SetColumn(button, 1);
                grid.Children.Add(button);

                // Add the Grid to the Border
                border.Child = grid;

                // Add the Border to the Canvas
                rightCanvas.Children.Add(border);

                yPosition += 60;
            }

            // Ajusta la altura del Canvas al contenido
            rightCanvas.Height = yPosition + 10;
        }
        private void OnPedidoReceived(Pedido[] pedidos)
        {
            Dispatcher.Invoke(() =>
            {
                leftCanvas.Children.Clear();
                LoadLeftList(pedidos);
            });
        }

        private void Pedirbtn_Click(object sender, RoutedEventArgs e)
        {
            _socketManager.SendPedido(PedidosManager.Instance.GetPedidos());
            PedidosManager.Instance.clearList();
            rightCanvas.Children.Clear();
            LoadRightList();
        }
    }
}
