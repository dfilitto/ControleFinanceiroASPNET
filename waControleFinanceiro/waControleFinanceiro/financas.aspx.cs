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
    public partial class financas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        public void AtualizaGrid()
        {
            DALFinanca dal = new DALFinanca();
            GridView1.DataSource = dal.Listar();
            GridView1.DataBind();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView1.SelectedIndex;
            int cod = Convert.ToInt32(GridView1.Rows[index].Cells[2].Text);
            DALFinanca dal = new DALFinanca();
            Financa f = dal.GetRegistro(cod);
            txbId.Text = f.Id.ToString();
            txbDescricao.Text = f.Descricao;
            txbValor.Text = f.Valor.ToString();
            if(f.Tipo == "Receita")
            {
                DLTipo.SelectedIndex = 0;
            }
            else
            {
                DLTipo.SelectedIndex = 1;
            }
            CData.SelectedDate = f.Data;
            btSalvar.Text = "Alterar";
        }
        public void LimpaCampos()
        {
            txbDescricao.Text = "";
            txbId.Text = "";
            txbValor.Text = "";
            btSalvar.Text = "Inserir";
        }
        protected void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                DALFinanca dal = new DALFinanca();
                Financa obj = new Financa();
                obj.Data = CData.SelectedDate;
                obj.Descricao = txbDescricao.Text;
                obj.Tipo = DLTipo.SelectedItem.Text;
                obj.Valor = Convert.ToDouble(txbValor.Text);
                obj.Usuario = Convert.ToInt32(Session["id"]);
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
                    dal.Alterar(obj);
                }
                Response.Write(msg);
               
                LimpaCampos();
            }
            catch (Exception erro)
            {
                Response.Write("<script> alert('" + erro.Message + "'); </script>");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            int cod = Convert.ToInt32(GridView1.Rows[index].Cells[2].Text);
            DALFinanca dal = new DALFinanca();
            dal.Excluir(cod);
            AtualizaGrid();
            
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    string item = e.Row.Cells[0].Text;
            //    foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
            //    {
            //        if (button.CommandName == "Delete")
            //        {
            //            button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
            //        }
            //    }
            //}
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }
    }
}