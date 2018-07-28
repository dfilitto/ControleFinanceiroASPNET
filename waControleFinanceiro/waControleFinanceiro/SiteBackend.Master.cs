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
    public partial class SiteBackend : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Session["email"] == null)
            {
               // Response.Redirect("~/login.aspx");
                
            }
            else
            {
                DALUsuario du = new DALUsuario();
                Usuario u = du.GetRegistro(Session["email"].ToString());
                AlteraMenu(u.Administrador);
            }
        }
        public void AlteraMenu(int administrador)
        {
            if (administrador == 1)
            {
                hlfinancas.Visible = false;
            }
            else
            {
                hlUsuario.Visible = false;
            }
        }
    }
}