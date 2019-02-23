using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppSchool.Models
{
    public class Login
    {
        //Conexão ao banco de dados
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BCD"].ConnectionString);
        //Variavéis
        private long cpf;
        private string senha;
        //Acesso à variavel
        public long Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public String Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        //MÉTODO LOGAR
        public bool Logar()
        {
            bool res = false;
            try
            {
                con.Open();
                SqlCommand query =
                    new SqlCommand("SELECT * FROM administrador WHERE cpf= @cpf AND senha = @senha", con);
                query.Parameters.AddWithValue("@cpf", Cpf);
                query.Parameters.AddWithValue("@senha", Senha);
                SqlDataReader leitor = query.ExecuteReader();

                res = leitor.HasRows;
            }
            catch (Exception e)
            {
                e.GetType();
                res = false;
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return res;
        }
    }
}