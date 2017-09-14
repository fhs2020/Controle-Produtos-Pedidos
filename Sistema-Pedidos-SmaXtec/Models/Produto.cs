using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Pedidos_SmaXtec.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public String NomeProduto { get; set; }
        public Decimal Preco { get; set; }
    }
}