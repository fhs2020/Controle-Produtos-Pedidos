using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Pedidos_SmaXtec.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public String UsuarioId { get; set; }
        public String NomeVendedor { get; set; }
        public int ClienteID { get; set; }
        public String ClienteNome { get; set; }
        public Cliente Cliente { get; set; }

        public int QuantidadeBase { get; set; }
        public int QuantRepetidor { get; set; }
        public int QuantSensorClimatico { get; set; }
        public int QuantAplicador { get; set; }
        public int QuantSensor { get; set; }
        public int QuantSensorPrimium { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }

        // Navigation Properties
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public List<Produto> Produtos { get; set; }

        // Navigation Properties
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}