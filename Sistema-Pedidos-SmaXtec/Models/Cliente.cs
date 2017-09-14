using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Pedidos_SmaXtec.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public String Nome { get; set; }
        public String CPF { get; set; }
        public int RG { get; set; }
        public String EnderecoResidencial { get; set; }
        public String EnderecoRural { get; set; }
        public String Documento { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }
        public String UserId { get; set; }
    }
}