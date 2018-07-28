using System;
using System.Collections.Generic;
using System.IO;
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
                if (cbAdm.Checked) obj.Administrador = 1; else obj.Administrador = 0;
                String caminho = Server.MapPath(@"imagens\usuarios\");
                //faz o upload da foto e salva o nome no obj
                if (fuFoto.PostedFile.FileName != "")
                {
                    obj.Foto = DateTime.Now.Millisecond.ToString() + fuFoto.PostedFile.FileName;
                    String img = caminho + obj.Foto;
                    fuFoto.PostedFile.SaveAs(img);
                }
                string msg = "<script> alert('Registro atualizado com sucesso!!!!'); </script>";

                if (txbId.Text == "")
                {
                    //inserir
                    dal.Inserir(obj);
                    msg = "<script> alert('O código gerado foi: " + obj.Id.ToString() + "'); </script>";
                }
                else
                {
                    obj.Id = Convert.ToInt32(txbId.Text);
                    //verificar se existe foto existe e deletar
                    Usuario uold = dal.GetRegistro(obj.Id);
                    if (uold.Foto != "")
                    {
                        File.Delete(caminho + uold.Foto);
                    }
                    dal.Alterar(obj);
                }
                Response.Write(msg);
                GridView1.DataBind();
                LimpaCampos();
            }
            catch (Exception erro)
            {
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
            btSalvar.Text = "Inserir";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text);
            DALUsuario du = new DALUsuario();
            Usuario u = du.GetRegistro(id);
            txbId.Text = id.ToString();
            txbEmail.Text = u.Email;
            txbNome.Text = u.Nome;
            if (u.Administrador == 1) cbAdm.Checked = true;
            else cbAdm.Checked = false;
            btSalvar.Text = "Alterar";
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);
            DALUsuario du = new DALUsuario();
            Usuario u = du.GetRegistro(id);
            if (u.Foto != "")
            {
                String caminho = Server.MapPath(@"imagens\usuarios\");
                File.Delete(caminho + u.Foto);
            }
        }
    }
}