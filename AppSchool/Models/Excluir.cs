using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppSchool.Models
{
    public class Excluir
    {
/**************************************************************************************CONEXAO BANCO DE DADOS**********************************************************************************************/
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BCD"].ConnectionString);
/**************************************************************************************VARIAVEIS**********************************************************************************************/

        private long cpf;
        private long cnpj;

/**********************************************************************************************GETERS E SETERS LIVROS**************************************************************************************/

        public long Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }
        public long Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

/********************************************************************************************REMOVER ALUNO****************************************************************************************/

        public string ExcluirAluno()
        {
            string res = "Deletado com sucesso!";                                   /*FUNFANDO*/
            try
            {
                con.Open();

                SqlCommand query =
                    new SqlCommand("DELETE FROM aluno WHERE cpf_usuario = @cpf_usuario", con);
                query.Parameters.AddWithValue("@cpf_usuario", Cpf);
                query.ExecuteNonQuery();
                query =
                    new SqlCommand("DELETE FROM usuario WHERE cpf = @cpf", con);
                query.Parameters.AddWithValue("@cpf", Cpf);
                query.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                res = e.Message;
            }

            if (con.State == System.Data.ConnectionState.Open)
                con.Close();

            return res;
        }

/********************************************************************************************REMOVER PROFESSOR****************************************************************************************/

        public string ExcluirProfessor()
        {
            string res = "Deletado com sucesso!";                                   /*FUNFANDO*/
            try
            {
                con.Open();

                SqlCommand query =
                    new SqlCommand("DELETE FROM professor WHERE cpf_usuario = @cpf_usuario", con);
                query.Parameters.AddWithValue("@cpf_usuario", Cpf);
                query.ExecuteNonQuery();
                query =
                   new SqlCommand("DELETE FROM usuario WHERE cpf = @cpf", con);
                query.Parameters.AddWithValue("@cpf", Cpf);
                query.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                res = e.Message;
            }

            if (con.State == System.Data.ConnectionState.Open)
                con.Close();

            return res;
        }

/********************************************************************************************REMOVER INSTITUICAO****************************************************************************************/

        public string ExcluirInstituicao()
        {
            string res = "Deletado com sucesso!";                                       /*FUNFANDO*/
            try
            {
                con.Open();

                SqlCommand query =
                    new SqlCommand("DELETE FROM instituicao WHERE cnpj = @cnpj", con);
                query.Parameters.AddWithValue("@cnpj", Cnpj);
                query.ExecuteNonQuery();              
            }
            catch (Exception e)
            {
                res = e.Message;
            }

            if (con.State == System.Data.ConnectionState.Open)
                con.Close();

            return res;
        }

/********************************************************************************************REMOVER NUTRICIONISTA****************************************************************************************/

        public string ExcluirNutricionista()
        {
            string res = "Deletado com sucesso!";
            try
            {
                con.Open();

                SqlCommand query =
                    new SqlCommand("DELETE FROM nutricionista WHERE cpf_usuario = @cpf_usuario", con);
                query.Parameters.AddWithValue("@cpf_usuario", Cpf);
                query.ExecuteNonQuery();
                query =
                   new SqlCommand("DELETE FROM usuario WHERE cpf = @cpf", con);
                query.Parameters.AddWithValue("@cpf", Cpf);
                query.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                res = e.Message;
            }

            if (con.State == System.Data.ConnectionState.Open)
                con.Close();

            return res;
        }
    }
}
