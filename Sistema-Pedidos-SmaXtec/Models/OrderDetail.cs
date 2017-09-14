using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Pedidos_SmaXtec.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public DateTime DataPedido { get; set; }

        // Navigation Properties
        public Produto Produto { get; set; }
        public Pedido Pedido { get; set; }

    }
}