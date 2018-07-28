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
    public partial class usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                DALUsuario dal = new DALUsuario();
                Usuario obj = new Usuario();
                obj.Nome = txbNome.Text;
                obj.Email = txbEmail.Text;
                obj.Senha = txbSenha.Text;
                String caminho = Server.MapPath(@"imagens\usuarios\");
                if(fuFoto.PostedFile.FileName!= "") obj.Foto = DateTime.Now.Millisecond.ToString()+fuFoto.PostedFile.FileName; 
                if (cbAdm.Checked) obj.Administrador = 1; else obj.Administrador = 0;
                if (txbId.Text == "")
                {
                    //inserir
                    dal.Inserir(obj);
                    String img = caminho + obj.Foto;
                    txbNome.Text = img;
                    if (fuFoto.PostedFile.FileName != "") fuFoto.PostedFile.SaveAs(img);
                    Response.Write("<script> alert('O código gerado foi: " + obj.Id.ToString() + "'); </script>");
                    GridView1.DataBind();
                    //LimpaCampos();
                }
                else
                {
                    //alterar
                }
            }catch(Exception erro)
            {
                txbNome.Text = erro.Message;
                Response.Write("<script> alert('" + erro.Message + "'); </script>");
                
            }

        }
        public void LimpaCampos()
        {
            txbId.Text = "";
            txbEmail.Text = "";
            txbNome.Text = "";
            txbSenha.Text = "";
            txbConfirmarSenha.Text = "";
            cbAdm.Checked = false;
        }
       
    }
}