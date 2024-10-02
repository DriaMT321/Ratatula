using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesaCliente.Class
{
    public class PedidosManager
    {
        private static PedidosManager _instance;
        private static readonly object _lock = new object();
        private List<Pedido> _pedidos;
        private int _numeroDeMesa;
        private int _currentId;
        private PedidosManager()
        {
            _pedidos = new List<Pedido>();
        }

        public static PedidosManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new PedidosManager();
                    }
                    return _instance;
                }
            }
        }

        public void AddPedido(String id,double precio)
        {
            var newPedido = new Pedido(_currentId++,id, _numeroDeMesa, "En espera",precio);
            _pedidos.Add(newPedido);
        }

        public Pedido[] GetPedidos()
        {
            return _pedidos.ToArray();
        }
        public void SetPedidos(Pedido[] nuevosPedidos)
        {
            lock (_lock)
            {
                _pedidos.Clear();
                _pedidos.AddRange(nuevosPedidos);
            }
        }
        public int NumeroDeMesa
        {
            get { return _numeroDeMesa; }
            set { _numeroDeMesa = value; }
        }
        public void clearList()
        {
            _pedidos.Clear();
        }
        public void quitar(Pedido asd)
        {
            _pedidos.Remove(asd);
        }
    }
}
