using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace waControleFinanceiro.Modelos
{
    public class Usuario
    {
        public Usuario()
        {
            this.Id = 0;
            this.Email = "";
            this.Foto = "";
            this.Administrador = 0;
            this.Nome = "";
            this.Senha = "";
        }
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Foto { get; set; }
        public String Senha { get; set; }
        int _adm;
        public int Administrador {
            get { return _adm; }
            set {
                if (value == 0 || value == 1) _adm = value;
                else _adm = 0;
            }
        }
    }
}