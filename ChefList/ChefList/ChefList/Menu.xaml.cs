using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ChefList
{
    public partial class MenuManagement : UserControl
    {
        private SocketManager _socketManager;
        private ObservableCollection<Comida> _comidasList;

        public MenuManagement(SocketManager socketManager)
        {
            InitializeComponent();
            _comidasList = new ObservableCollection<Comida>();
            DataContext = new MenuManagementViewModel { ComidasList = _comidasList };

            _socketManager = socketManager;
            _socketManager.ComidasDataReceived += ProcessReceivedData;

            // Solicitar la lista de comidas al iniciar
            RequestComidasFromServer();
        }

        private void ProcessReceivedData(Comida[] comidas)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _comidasList.Clear();
                foreach (var comida in comidas)
                {
                    _comidasList.Add(comida);
                }
            });
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (MenuManagementViewModel)DataContext;
            var newComida = new Comida();
            var dialog = new ComidaDialog(newComida);
            if (dialog.ShowDialog() == true)
            {
                viewModel.ComidasList.Add(newComida);
                SendComidasToServer(viewModel.ComidasList);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (MenuManagementViewModel)DataContext;
            if (viewModel.SelectedComida != null)
            {
                var dialog = new ComidaDialog(viewModel.SelectedComida);
                if (dialog.ShowDialog() == true)
                {
                    // Actualizar la lista en el servidor después de editar
                    SendComidasToServer(viewModel.ComidasList);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (MenuManagementViewModel)DataContext;
            if (viewModel.SelectedComida != null)
            {
                // Eliminar el elemento seleccionado de la lista
                var comidaToRemove = viewModel.SelectedComida;
                viewModel.ComidasList.Remove(comidaToRemove);

                // Actualizar la lista en el servidor después de eliminar
                SendComidasToServer(viewModel.ComidasList);
            }
        }

        private void SendComidasToServer(ObservableCollection<Comida> comidasList)
        {
            var comidasArray = new Comida[comidasList.Count];
            comidasList.CopyTo(comidasArray, 0);
            _socketManager.SendData(comidasArray, "COMIDA");

            // Solicitar la lista de comidas actualizada del servidor
            RequestComidasFromServer();
        }

        private void RequestComidasFromServer()
        {
            _socketManager.SendRequest("MENU");
        }
    }
}
