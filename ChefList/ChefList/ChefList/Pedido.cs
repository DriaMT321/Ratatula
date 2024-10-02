using System.ComponentModel;

namespace ChefList
{
    public class Pedido : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string NombreComida { get; set; }
        public int Mesa { get; set; }
        private string estado;
        public DateTime FechaHora { get; set; }
        public double Precio { get; set; }
        public string Estado
        {
            get { return estado; }
            set
            {
                if (estado != value)
                {
                    estado = value;
                    OnPropertyChanged(nameof(Estado));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
