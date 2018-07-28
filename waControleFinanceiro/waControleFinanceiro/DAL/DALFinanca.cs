using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using waControleFinanceiro.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace waControleFinanceiro.DAL
{
    public class DALFinanca
    {
        public void Inserir(Financa obj)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["mymoneyConnectionString"];
            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into financas (descricao,data,valor,usuario,tipo) values (@descricao,@data,@valor,@usuario,@tipo);select @@IDENTITY;";
            cmd.Parameters.AddWithValue("descricao", obj.Descricao);
            cmd.Parameters.AddWithValue("data", obj.Data);
            cmd.Parameters.AddWithValue("valor", obj.Valor);
            cmd.Parameters.AddWithValue("usuario", obj.Usuario);
            cmd.Parameters.AddWithValue("tipo", obj.Tipo);
            con.Open();
            obj.Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }

        public void Alterar(Financa obj)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["mymoneyConnectionString"];
            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update financas set descricao=@descricao, data=@data, valor=@valor, usuario=@usuario, tipo=@tipo where id = @id;";
            cmd.Parameters.AddWithValue("descricao", obj.Descricao);
            cmd.Parameters.AddWithValue("data", obj.Data);
            cmd.Parameters.AddWithValue("valor", obj.Valor);
            cmd.Parameters.AddWithValue("usuario", obj.Usuario);
            cmd.Parameters.AddWithValue("tipo", obj.Tipo);
            cmd.Parameters.AddWithValue("id", obj.Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int cod)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["mymoneyConnectionString"];
            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from financas where id = "+cod.ToString();
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable Listar()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["mymoneyConnectionString"];

            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from financas", connString.ConnectionString);
            da.Fill(tabela);
            return tabela;
        }

        public DataTable Localizar(String valor)
        {
            
            DataTable tabela = new DataTable();
            /*
            SqlDataAdapter da = new SqlDataAdapter("Select * from categoria where cat_nome like '%" +
                valor + "%'", DadosDoBanco.stringDeConexao);
            da.Fill(tabela);*/
            return tabela;
        }

        public Financa GetRegistro(int id)
        {
            Financa obj = new Financa();

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["mymoneyConnectionString"];

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from financas where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                obj.Id = Convert.ToInt32(registro["id"]);
                obj.Descricao = Convert.ToString(registro["descricao"]);
                obj.Data = Convert.ToDateTime(registro["data"]);
                obj.Usuario = Convert.ToInt32(registro["usuario"]);
                obj.Valor = Convert.ToDouble(registro["valor"]);
                obj.Tipo = Convert.ToString(registro["tipo"]);
            }
            con.Close();
            return obj;
        }

       
    }
}