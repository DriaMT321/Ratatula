using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesaCliente.Class
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NombreComida { get; set; }
        public int Mesa { get; set; }
        public string Estado { get; set; }
        public DateTime FechaHora { get; set; }
        public double Precio { get; set; }

        public Pedido(int id, string comida, int mesa, string estado, double precio)
        {
            this.Id = id;
            this.NombreComida = comida;
            this.Mesa = mesa;
            this.Estado = estado;
            this.FechaHora = DateTime.Now;
            Precio = precio;
        }
    }

}
