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
    /// Lógica de interacción para Pagar.xaml
    /// </summary>
    public partial class Pagar : UserControl
    {
        private SocketManager _socketManager;
        public Pagar(SocketManager socketManager)
        {
            InitializeComponent();
            _socketManager = socketManager;
            _socketManager.PedidoReceived += OnPedidoReceived;
        }
        private void OnPedidoReceived(Pedido[] pedidos)
        {
            Dispatcher.Invoke(() =>
            {
                leftCanvas.Children.Clear();
                LoadLeftList(pedidos);
            });
        }
        private void LoadLeftList(Pedido[] pedidos)
        {
            // Filtrar los pedidos que están listos
            var pedidosListos = pedidos.Where(p => p.Estado == "Listo").ToArray();

            double total = 0;
            double yPosition = 10;
            foreach (var item in pedidosListos)
            {
                // Sumar el total
                total += item.Precio;

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

                // Create the Grid to hold the label and price
                var grid = new Grid
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch
                };
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                // Create the label for the name of the food
                var nameLabel = new Label
                {
                    Content = item.NombreComida,
                    FontSize = 16,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                Grid.SetColumn(nameLabel, 0);
                grid.Children.Add(nameLabel);

                // Create the label for the price
                var priceLabel = new Label
                {
                    Content = item.Precio.ToString("C"),
                    FontSize = 16,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Margin = new Thickness(0, 0, 10, 0)
                };
                Grid.SetColumn(priceLabel, 1);
                grid.Children.Add(priceLabel);

                // Add the Grid to the Border
                border.Child = grid;

                // Add the Border to the Canvas
                leftCanvas.Children.Add(border);

                yPosition += 60;
            }

            // Ajusta la altura del Canvas al contenido
            leftCanvas.Height = yPosition + 10;

            // Mostrar el total a pagar
            totalTextBlock.Text = $"Total: {total:C}";
        }
        private void endServicebtn_Click(object sender, RoutedEventArgs e)
        {
            _socketManager.SendRequest("END_SERVICE");
        }
    }
}
