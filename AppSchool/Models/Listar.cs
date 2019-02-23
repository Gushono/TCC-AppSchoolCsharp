using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppSchool.Models
{
    
    public class Listar
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BCD"].ConnectionString);

        private long cpf;

        public long Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        //LISTAR ALUNO
        
        public  List<Cadastro> ListarAluno()
        {
            string res = "Lista funciona";
            
            List<Cadastro> lista = new List<Cadastro>();
            try
            {
                con.Open();
                SqlCommand query = new SqlCommand("SELECT * FROM aluno, Salas WHERE cpf_usuario = @cpf_usuario AND turma_saladeAula = saladeAula", con);
                query.Parameters.AddWithValue("@cpf_usuario", Cpf);
                SqlDataReader leitor = query.ExecuteReader();

                while (leitor.Read())
                {
                    Cadastro a = new Cadastro();

                    a.Frequencia = leitor["frequencia"].GetHashCode();
                    a.Almoco = leitor["almoco"].ToString();
                    a.Turma = leitor["saladeAula"].ToString();
                    a.Rm = leitor["rm"].GetHashCode();
                    a.Cpf = (long)leitor["cpf_usuario"];
                    a.Cnpj = (long)leitor["cnpj_instituicao"];
                    leitor.Close();

                    query = new SqlCommand("SELECT * FROM usuario where cpf = @cpf", con);
                    query.Parameters.AddWithValue("@cpf", a.Cpf);
                    leitor = query.ExecuteReader();

                    while (leitor.Read())
                    {

                        a.Cpf = (long)leitor["cpf"];
                        a.Senha = leitor["senha"].ToString();
                        a.Nome = leitor["nome"].ToString();
                        a.Sexo = leitor["sexo"].ToString();
                        a.Rg = leitor["rg"].ToString();
                        DateTime data = (DateTime)leitor["nascimento"];

                        a.Nascimento = data;
                        a.Nascimento.ToShortDateString();
                        a.Celular = leitor["celular"].GetHashCode();
                        a.Email = leitor["email"].ToString();
                        a.Foto = (byte[])leitor["foto"];
                        a.Cidade = leitor["cidade"].ToString();
                        a.Endereco = leitor["endereco"].ToString();
                        a.Cep = leitor["cep"].GetHashCode();
                        a.Numero = leitor["numero"].GetHashCode();
                        lista.Add(a);

                    }
                }
                leitor.Close();       
            
            }
            catch (Exception e)
            {
                res = e.Message;
                lista = null;
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return lista;
        }
        //listar almoço
        public List<Cadastro> ListarAlmoco()
        {
            string res = "Lista funciona";

            List<Cadastro> lista = new List<Cadastro>();
            try
            {
                con.Open();
                SqlCommand query = new SqlCommand("SELECT cpf_usuario, rm, nome FROM aluno, Usuario WHERE almoco = 'Sim' AND cpf_usuario = cpf", con);
                SqlDataReader leitor = query.ExecuteReader();

                while (leitor.Read())
                {
                    Cadastro a = new Cadastro();
                    a.Cpf = (long)leitor["cpf_usuario"];
                    a.Rm = leitor["rm"].GetHashCode();
                    a.Nome = leitor["nome"].ToString();
                    lista.Add(a);                
                }
                leitor.Close();
            }
            catch (Exception e)
            {
                res = e.Message;
                lista = null;
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return lista;
        }
        //LISTAR PROFESSOR
        public List<Cadastro> ListarProfessor()
        {
            string res = "Lista funciona";
            List<Cadastro> lista = new List<Cadastro>();
            try
            {
                con.Open();
                SqlCommand query =
                    new SqlCommand("SELECT * FROM professor, usuario, instituicao WHERE cpf_usuario = @cpf_usuario AND cpf_usuario = cpf AND cnpj_instituicao = cnpj", con);
                query.Parameters.AddWithValue("@cpf_usuario", Cpf);
                
                SqlDataReader leitor = query.ExecuteReader();

                while (leitor.Read())
                {
                    Cadastro a = new Cadastro();

                    a.Materia = leitor["materia"].ToString();
                    a.Cpf = (long) leitor["cpf_usuario"];
                    a.Cnpj = (long)leitor["cnpj_instituicao"];
                        a.Senha = leitor["senha"].ToString();
                        a.Nome = leitor["nome"].ToString();
                        a.Sexo = leitor["sexo"].ToString();
                        a.Rg = leitor["rg"].ToString();
                        DateTime data = (DateTime)leitor["nascimento"];
                        a.Nascimento = data;
                        a.Nascimento.ToShortDateString();
                        a.Celular = leitor["celular"].GetHashCode();
                        a.Email = leitor["email"].ToString();
                        a.Foto = (byte[])leitor["foto"];
                        a.Cidade = leitor["cidade"].ToString();
                        a.Endereco = leitor["endereco"].ToString();
                        a.Cep = leitor["cep"].GetHashCode();
                        a.Numero = leitor["numero"].GetHashCode();                      
                        lista.Add(a);

                    }              
                leitor.Close();

            }
            catch (Exception e)
            {
                res = e.Message;
                lista = null;
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return lista;
        }

        //LISTAR NUTRICIONISTA
        public List<Cadastro> ListarNutricionista()
        {
            string res = "Lista funciona";
            List<Cadastro> lista = new List<Cadastro>();
            try
            {
                con.Open();
                SqlCommand query =
                    new SqlCommand("SELECT * FROM nutricionista, usuario, instituicao WHERE cpf_usuario = @cpf_usuario AND cpf_usuario = cpf AND cnpj_instituicao = cnpj", con);
                query.Parameters.AddWithValue("@cpf_usuario", Cpf);
                SqlDataReader leitor = query.ExecuteReader();
                while (leitor.Read())
                {
                    Cadastro a = new Cadastro();

                    a.Cpf = (long)leitor["cpf_usuario"].GetHashCode();
                    a.Cnpj = (long)leitor["cnpj_instituicao"];
                        a.Senha = leitor["senha"].ToString();
                        a.Nome = leitor["nome"].ToString();
                        a.Sexo = leitor["sexo"].ToString();
                        a.Rg = leitor["rg"].ToString();
                        DateTime data = (DateTime)leitor["nascimento"];
                        a.Nascimento = data;
                        a.Nascimento.ToShortDateString();
                        a.Celular = leitor["celular"].GetHashCode();
                        a.Email = leitor["email"].ToString();
                        a.Foto = (byte[])leitor["foto"];
                        a.Cidade = leitor["cidade"].ToString();
                        a.Endereco = leitor["endereco"].ToString();
                        a.Cep = leitor["cep"].GetHashCode();
                        a.Numero = leitor["numero"].GetHashCode();
                        
                       lista.Add(a);

                    }             
                leitor.Close();

            }
            catch (Exception e)
            {
                res = e.Message;
                lista = null;
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return lista;
        }
        //LISTAR INSTITUIÇÃO
        public List<Cadastro> ListarInstituicao()
        {
            string res = "Lista funciona";
            List<Cadastro> lista = new List<Cadastro>();
            try
            {
                con.Open();
                SqlCommand query =
                    new SqlCommand("SELECT * FROM instituicao", con);
                SqlDataReader leitor = query.ExecuteReader();

                while (leitor.Read())
                {
                    Cadastro a = new Cadastro();

                    a.Cnpj = (long)leitor["cnpj"].GetHashCode();
                    a.NomeInst = leitor["nomeInst"].ToString();
                    a.Telefone = leitor["telefone"].GetHashCode();
                    a.Cep = leitor["cep"].GetHashCode();
                    a.Endereco = leitor["endereco"].ToString();
                    a.Numero = leitor["numero"].GetHashCode();
                    lista.Add(a);
                }         
            }
            catch (Exception e)
            {
                res = e.Message;
                lista = null;
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return lista;
        }

    }
}