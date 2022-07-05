using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitulo06.Labs.Models
{
    public class Fatura
    {
        public int Id { get; set; }
        public string NumeroCartao { get; set; }
        public string NumeroPedido { get; set; }
        public double Valor { get; set; }
        public int Status { get; set; }

    }
}