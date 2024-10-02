using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ChefList
{
    public class ComidaDialogViewModel : INotifyPropertyChanged
    {
        public Comida Comida { get; set; }
        public ObservableCollection<string> Categorias { get; set; }

        public ComidaDialogViewModel(Comida comida)
        {
            Comida = comida;
            Categorias = new ObservableCollection<string>
            {
                "Sopa",
                "Segundo",
                "Bebida",
                "Postre"
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
