using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using waControleFinanceiro.DAL;
using waControleFinanceiro.Modelos;

namespace waControleFinanceiro
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btlogar_Click(object sender, EventArgs e)
        {
            string email = txbLogin.Text;
            string senha = txbSenha.Text;
 
            DALUsuario du = new DALUsuario();
            Usuario u = du.GetRegistro(email);
            if (email == u.Email && senha == u.Senha)
            {
                Session["id"] = u.Id;
                Session["nome"] = u.Nome;
                Session["email"] = email;
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}