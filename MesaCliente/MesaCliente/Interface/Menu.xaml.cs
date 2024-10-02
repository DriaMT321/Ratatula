using MesaCliente.Class;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MesaCliente.Interface
{
    public partial class Menu : UserControl
    {
        private SocketManager _socketManager;
        private string selectedCategory = "Todo"; // Default filter
        private Comida[] TheMenu;

        public Menu(SocketManager socketManager)
        {
            InitializeComponent();
            _socketManager = socketManager;
            _socketManager.MenuReceived += OnMenuReceived;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Ensure that the comidasStackPanel is initialized before using it
            if (TheMenu != null)
            {
                LoadComidas(TheMenu);
            }
        }

        private void LoadComidas(Comida[] comidas)
        {
            if (comidasStackPanel == null) return; // Ensure comidasStackPanel is initialized

            comidasStackPanel.Children.Clear(); // Clear existing items

            var filteredComidas = selectedCategory == "Todo" ? comidas : comidas.Where(c => c.Categoria == selectedCategory).ToArray();

            foreach (var comida in filteredComidas)
            {
                // Create the button for each comida
                var button = new Button
                {
                    Content = comida.Nombre,
                    Width = 180,
                    Height = 50,
                    Tag = comida, // Vinculando el objeto Comida con el botón
                    Margin = new Thickness(10),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Style = (Style)FindResource("RoundedButtonStyle") // Aplicando el estilo redondeado
                };

                // Define colores personalizados usando recursos dinámicos
                button.Resources["ButtonBackground"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#d74e09"));
                button.Resources["ButtonForeground"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f0f0c9"));

                button.Click += ComidaButton_Click;

                // Add the button to the stack panel
                comidasStackPanel.Children.Add(button);
            }
        }

        private void ComidaButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var comida = button.Tag as Comida; // Recuperando el objeto Comida vinculado
                if (comida != null)
                {
                    // Load details view for selected comida
                    detailsContentControl.Content = new Detailfood(comida);
                }
            }
        }

        private void OnMenuReceived(Comida[] Menu)
        {
            Dispatcher.Invoke(() =>
            {
                TheMenu = Menu;
                LoadComidas(Menu);
            });
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            if (filtroPanel.Visibility == Visibility.Collapsed)
            {
                filtroPanel.Visibility = Visibility.Visible;
            }
            else
            {
                filtroPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                selectedCategory = radioButton.Content.ToString();
                LoadComidas(TheMenu);
            }
        }
    }
}
