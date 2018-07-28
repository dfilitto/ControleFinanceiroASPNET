using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using waControleFinanceiro.DAL;
using waControleFinanceiro.Modelos;

namespace waControleFinanceiro.UI
{
    public partial class Default : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                DALUsuario du = new DALUsuario();
                Usuario u = du.GetRegistro(Session["email"].ToString());
                lbNome.Text = u.Nome;
                lbEmail.Text = u.Email;
                IUser.ImageUrl = "imagens/usuarios/"+u.Foto;
            }
        }
    }
}