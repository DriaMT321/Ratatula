using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ChefList
{
    public class MenuManagementViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Comida> ComidasList { get; set; }
        private Comida _selectedComida;
        public Comida SelectedComida
        {
            get { return _selectedComida; }
            set
            {
                if (_selectedComida != value)
                {
                    _selectedComida = value;
                    OnPropertyChanged("SelectedComida");
                    OnPropertyChanged("IsComidaSelected");
                }
            }
        }

        public bool IsComidaSelected => SelectedComida != null;

        public MenuManagementViewModel()
        {
            ComidasList = new ObservableCollection<Comida>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
