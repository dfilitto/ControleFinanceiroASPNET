using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using waControleFinanceiro.Modelos;

namespace waControleFinanceiro.DAL
{
    public class DALUsuario
    {
        public void Inserir(Usuario obj)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["mymoneyConnectionString"];
            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into usuarios (email, nome, senha, foto, administrador) values (@email,@nome,@senha,@foto,@administrador);select @@IDENTITY;";
            cmd.Parameters.AddWithValue("email", obj.Email);
            cmd.Parameters.AddWithValue("nome", obj.Nome);
            cmd.Parameters.AddWithValue("senha", obj.Senha);
            cmd.Parameters.AddWithValue("foto", obj.Foto);
            cmd.Parameters.AddWithValue("administrador", obj.Administrador);
            con.Open();
            obj.Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }

        public void Alterar(Usuario obj)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["mymoneyConnectionString"];
            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update usuarios set email=@email, nome = @nome, senha = @senha, foto = @foto, administrador = @administrador where id = @id;";
            cmd.Parameters.AddWithValue("email", obj.Email);
            cmd.Parameters.AddWithValue("nome", obj.Nome);
            cmd.Parameters.AddWithValue("senha", obj.Senha);
            cmd.Parameters.AddWithValue("foto", obj.Foto);
            cmd.Parameters.AddWithValue("administrador", obj.Administrador);
            cmd.Parameters.AddWithValue("id", obj.Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir()
        {

        }

        public Usuario GetRegistro(int id)
        {
            Usuario obj = new Usuario();

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["mymoneyConnectionString"];

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from usuarios where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                obj.Id = Convert.ToInt32(registro["id"]);
                obj.Email = Convert.ToString(registro["email"]);
                obj.Foto = Convert.ToString(registro["foto"]);
                obj.Nome = Convert.ToString(registro["nome"]);
                obj.Senha = Convert.ToString(registro["senha"]);
                obj.Administrador = Convert.ToInt32(registro["administrador"]);
            }
            con.Close();
            return obj;
        }

        public Usuario GetRegistro(String email)
        {
            Usuario obj = new Usuario();

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["mymoneyConnectionString"];

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from usuarios where email = @email";
            cmd.Parameters.AddWithValue("@email", email);
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                obj.Id = Convert.ToInt32(registro["id"]);
                obj.Email = Convert.ToString(registro["email"]);
                obj.Foto = Convert.ToString(registro["foto"]);
                obj.Nome = Convert.ToString(registro["nome"]);
                obj.Senha = Convert.ToString(registro["senha"]);
                obj.Administrador = Convert.ToInt32(registro["administrador"]);
            }
            con.Close();
            return obj;
        }
    }
}