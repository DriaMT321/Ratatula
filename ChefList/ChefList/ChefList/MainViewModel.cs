using System.Collections.ObjectModel;

namespace ChefList
{
    public class MainViewModel
    {
        public ObservableCollection<Pedido> DataList { get; set; }

        public MainViewModel()
        {
            DataList = new ObservableCollection<Pedido>();
        }
    }
}
