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
    /// Lógica de interacción para Detailfood.xaml
    /// </summary>
    public partial class Detailfood : UserControl
    {
        Comida food;
        public Detailfood(Comida comida)
        {
            InitializeComponent();
            food = comida;
            txtName.Text = food.Nombre;
            DescriptionText.Text = food.Descripcion;
            PriceText.Text = $"BS {food.Precio}";
            CategoryText.Text =$"Categoría: {food.Categoria}";
        }

        private void addbtn_Click(object sender, RoutedEventArgs e)
        {
            PedidosManager.Instance.AddPedido(food.Nombre,food.Precio);
        }
    }
}
