using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppSchool.Models
{
    public class BancoDeDados
    {
       SqlConnection con = new SqlConnection("Server=ESN509VMSSQL;Database=AppSchool;User id = Aluno;Password=Senai1234");

        public long cpf;
        public string codigo;
        public String confirmaEmail()
        {
            String lista = "";
            Random rand = new Random();
            for (int i = 0; i <= 5; i++)
            {
                int numRandom = rand.Next(65, 90);
                lista += Convert.ToChar(numRandom);
            }

            return lista;
        }

        public Boolean atualizaSenha()
        {
            Boolean teste = false;
            try
            {
                con.Open();

                SqlCommand comandoSelect = new SqlCommand("Select * from esqueciSenha where codigo = @codigo and cpf_esqueciSenha = @cpf", con);
                comandoSelect.Parameters.AddWithValue("@codigo", codigo);
                comandoSelect.Parameters.AddWithValue("@cpf", cpf);

                SqlDataReader leitor = comandoSelect.ExecuteReader();

                if (leitor.HasRows)
                {
                    while (leitor.Read())
                    {

                        leitor["codigo"].ToString();
                        leitor["cpf_esqueciSenha"].ToString();

                        teste = true;
                    }
                }
                else
                {
                    return teste;
                }

                if (teste.Equals(true))
                {
                    List<Char> listaRandom = new List<Char>();
                    Random rand = new Random();
                    String lista = "";
                    for (int i = 0; i <= 5; i++)
                    {
                        int numRandom = rand.Next(1, 9);
                        lista += numRandom;
                    }
                    SqlCommand comandoUpdate = new SqlCommand("UPDATE usuario set senha = @senha where cpf_esqueciSenha = @cpf");
                    comandoUpdate.Parameters.AddWithValue("@senha", codigo);
                    comandoUpdate.Parameters.AddWithValue("@cpf", cpf);
                    comandoUpdate.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                e.GetType();
            }

            finally
            {
                con.Close();
            }
            return teste;
        }
    }
}