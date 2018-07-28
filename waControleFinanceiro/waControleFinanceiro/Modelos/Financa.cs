using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waControleFinanceiro.Modelos
{
    public class Financa
    {
        public int Id { get; set; }
        public String Descricao { get; set; }
        public DateTime Data { get; set; }
        public Double Valor { get; set; }
        public int Usuario { get; set; }
        public String Tipo { get; set; }
    }
}