using System.Windows;

namespace ChefList
{
    public partial class ComidaDialog : Window
    {
        public ComidaDialog(Comida comida)
        {
            InitializeComponent();
            DataContext = new ComidaDialogViewModel(comida);
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
