using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppSchool.Models
{
    public class Editar
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BCD"].ConnectionString);

        private string almoco, turma, senha, nome, sexo, email, endereco, cidade, rg, materia, nomeInst;
        private long cpf, cnpj;
        private int rm, frequencia, celular, cep, numero, telefone;
        private DateTime nascimento;
        private Byte[] foto, fotoCardapio;

        public long Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }
        public string Rg
        {
            get { return rg; }
            set { rg = value; }
        }
        public string NomeInst
        {
            get { return nomeInst; }
            set { nomeInst = value; }
        }
        public int Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        public int Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        public int Cep
        {
            get { return cep; }
            set { cep = value; }
        }
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public int Frequencia
        {
            get { return frequencia; }
            set { frequencia = value; }
        }
        public int Rm
        {
            get { return rm; }
            set { rm = value; }
        }
        public long Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Almoco
        {
            get { return almoco; }
            set { almoco = value; }
        }
        public string Turma
        {
            get { return turma; }
            set { turma = value; }
        }
        public string Materia
        {
            get { return materia; }
            set { materia = value; }
        }
        public DateTime Nascimento
        {
            get { return nascimento; }
            set { nascimento = value; }
        }
        public Byte[] Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        public Byte[] FotoCardapio
        {
            get { return fotoCardapio; }
            set { fotoCardapio = value; }
        }

/********************************************************************BUSCA ALUNO**********************************************************************************/

        public Editar buscaAluno(long id)
        {
            string res = "Editar funciona";

            Editar a = new Editar();
            try
            {
                con.Open();
                SqlCommand query = new SqlCommand("SELECT * FROM aluno, Salas, usuario WHERE cpf_usuario = @cpf_usuario AND turma_saladeAula = saladeAula AND cpf_usuario = cpf", con);
                query.Parameters.AddWithValue("@cpf_usuario", id);
                SqlDataReader leitor = query.ExecuteReader();

                while (leitor.Read())
                {
                   
                        a.Frequencia = leitor["frequencia"].GetHashCode();
                        a.Almoco = leitor["almoco"].ToString();
                        a.Turma = leitor["saladeAula"].ToString();
                        a.Rm = leitor["rm"].GetHashCode();
                        a.Cpf = (long)leitor["cpf_usuario"];
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
                    }               
                leitor.Close();

            }
            catch (Exception e)
            {
                res = e.Message;
                a = null;
            }

            if (con.State == System.Data.ConnectionState.Open)
                con.Close();

            return a;
        }

/********************************************************************BUSCA PROFESSOR**********************************************************************************/

        public Cadastro buscaProfessor(long id)
        {
            string res = "Editar funciona";
            Cadastro a = new Cadastro();
            try
            {
                con.Open();
                SqlCommand query = new SqlCommand("SELECT * FROM professor WHERE cpf_usuario = @cpf_usuario", con);
                query.Parameters.AddWithValue("@cpf_usuario", id);
                SqlDataReader leitor = query.ExecuteReader();

                while (leitor.Read())
                {
                    a.Materia = leitor["materia"].ToString();
                    a.Cpf = (long)leitor["cpf_usuario"];
                    a.Cnpj = (long)leitor["cnpj_instituicao"];
                    leitor.Close();

                    query = new SqlCommand("SELECT * FROM usuario where cpf = @cpf", con);
                    query.Parameters.AddWithValue("@cpf", a.Cpf);
                    leitor = query.ExecuteReader();

                    while (leitor.Read())
                    {

                        a.Nome = leitor["nome"].ToString();
                        a.Cpf = (long)leitor["cpf"];
                        a.Rg = leitor["rg"].ToString();
                        DateTime data = (DateTime)leitor["nascimento"];

                        a.Nascimento = data;
                        a.Nascimento.ToShortDateString();
                        a.Sexo = leitor["sexo"].ToString();
                        a.Email = leitor["email"].ToString();
                        a.Cep = leitor["cep"].GetHashCode();
                        a.Cidade = leitor["cidade"].ToString();
                        a.Endereco = leitor["endereco"].ToString();
                        a.Numero = leitor["numero"].GetHashCode();
                        a.Celular = leitor["celular"].GetHashCode();
                        //a.Materia = leitor["materia"].ToString();
                        a.Senha = leitor["senha"].ToString();                     
                        a.Foto = (byte[])leitor["foto"];
                    }
                }
                leitor.Close();

            }
            catch (Exception e)
            {
                res = e.Message;
                a = null;
            }

            if (con.State == System.Data.ConnectionState.Open)
                con.Close();

            return a;
        }

/********************************************************************BUSCA NUTRICIONISTA**********************************************************************************/

        public Cadastro buscaNutricionista(long id)
        {
            string res = "Editar funciona";
            Cadastro a = new Cadastro();
            try
            {
                con.Open();
                SqlCommand query = new SqlCommand("SELECT * FROM nutricionista WHERE cpf_usuario = @cpf_usuario", con);
                query.Parameters.AddWithValue("@cpf_usuario", id);
                SqlDataReader leitor = query.ExecuteReader();

                while (leitor.Read())
                {
                    a.FotoCardapio = (byte[])leitor["fotoCardapio"];
                    a.Cpf = (long)leitor["cpf_usuario"];
                    a.Cnpj = (long)leitor["cnpj_instituicao"];
                    leitor.Close();

                    query = new SqlCommand("SELECT * FROM usuario where cpf = @cpf", con);
                    query.Parameters.AddWithValue("@cpf", a.Cpf);
                    leitor = query.ExecuteReader();

                    while (leitor.Read())
                    {

                        a.Nome = leitor["nome"].ToString();
                        a.Cpf = (long)leitor["cpf"];
                        a.Rg = leitor["rg"].ToString();
                        DateTime data = (DateTime)leitor["nascimento"];

                        a.Nascimento = data;
                        a.Nascimento.ToShortDateString();
                        a.Sexo = leitor["sexo"].ToString();
                        a.Email = leitor["email"].ToString();
                        a.Cep = leitor["cep"].GetHashCode();
                        a.Cidade = leitor["cidade"].ToString();
                        a.Endereco = leitor["endereco"].ToString();
                        a.Numero = leitor["numero"].GetHashCode();
                        a.Celular = leitor["celular"].GetHashCode();
                        //a.Materia = leitor["materia"].ToString();
                        a.Senha = leitor["senha"].ToString();
                        a.Foto = (byte[])leitor["foto"];
                    }
                }
                leitor.Close();

            }
            catch (Exception e)
            {
                res = e.Message;
                a = null;
            }

            if (con.State == System.Data.ConnectionState.Open)
                con.Close();

            return a;
        }

/********************************************************************ALUNO**********************************************************************************/

        public string EditaAluno(long id)                   
        {
            string res = "Salvo com sucesso!";              /*FUNFANDO*/
            try
            {
                con.Open();

                SqlCommand query =
                    new SqlCommand("UPDATE aluno SET frequencia = @frequencia, almoco = @almoco,turma_saladeAula = @turma,"
                    + "rm = @rm, cnpj_instituicao=@cnpj_instituicao WHERE cpf_usuario = @cpf_usuario", con);

                query.Parameters.AddWithValue("@frequencia", Frequencia);
                query.Parameters.AddWithValue("@almoco", Almoco);
                query.Parameters.AddWithValue("@turma", Turma);
                query.Parameters.AddWithValue("@rm", Rm);
                query.Parameters.AddWithValue("@cnpj_instituicao", Cnpj);
                query.Parameters.AddWithValue("@cpf_usuario", Cpf);

                query.ExecuteNonQuery();

                query = new SqlCommand("UPDATE usuario SET senha = @senha, nome = @nome, sexo = @sexo,"
                    + "rg = @rg, nascimento = @nascimento, celular = @celular, email = @email, cidade = @cidade,"
                    + "endereco = @endereco, cep = @cep, numero = @numero WHERE cpf = @cpf", con);

                query.Parameters.AddWithValue("@cpf", Cpf);
                query.Parameters.AddWithValue("@senha", Senha);
                query.Parameters.AddWithValue("@nome", Nome);
                query.Parameters.AddWithValue("@sexo", Sexo);
                query.Parameters.AddWithValue("@rg", Rg);
                query.Parameters.AddWithValue("@nascimento", Nascimento);
                query.Parameters.AddWithValue("@celular", Celular);
                query.Parameters.AddWithValue("@email", Email);
               // query.Parameters.AddWithValue("@foto", Foto);
                query.Parameters.AddWithValue("@cidade", Cidade);
                query.Parameters.AddWithValue("@endereco", Endereco);
                query.Parameters.AddWithValue("@cep", Cep);
                query.Parameters.AddWithValue("@numero", Numero);

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

/********************************************************************PROFESSOR**********************************************************************************/

        public string EditarProfessor(long id)                      /*FUNFANDO*/
        {
            string res = "Salvo com sucesso!";
            try
            {
                con.Open();

                SqlCommand query =
                    new SqlCommand("UPDATE professor SET materia = @materia, cpf_usuario = @cpf_usuario, cnpj_instituicao=@cnpj_instituicao WHERE cpf_usuario = @cpf_usuario", con);

                query.Parameters.AddWithValue("@materia", Materia);
                query.Parameters.AddWithValue("@cpf_usuario", Cpf);
                query.Parameters.AddWithValue("@cnpj_instituicao", Cnpj);

                query.ExecuteNonQuery();

                query = new SqlCommand("UPDATE usuario SET cpf = @cpf, senha = @senha, nome = @nome, sexo = @sexo," 
                   + "rg = @rg, nascimento = @nascimento, celular = @celular, email = @email, cidade =  @cidade,"
                   + "endereco = @endereco, cep = @cep, numero = @numero WHERE cpf = @cpf", con);

                query.Parameters.AddWithValue("@cpf", Cpf);
                query.Parameters.AddWithValue("@senha", Senha);
                query.Parameters.AddWithValue("@nome", Nome);
                query.Parameters.AddWithValue("@sexo", Sexo);
                query.Parameters.AddWithValue("@rg", Rg);
                query.Parameters.AddWithValue("@nascimento", Nascimento);
                query.Parameters.AddWithValue("@celular", Celular);
                query.Parameters.AddWithValue("@email", Email);
               // query.Parameters.AddWithValue("@foto", Foto); 
                query.Parameters.AddWithValue("@cidade", Cidade);
                query.Parameters.AddWithValue("@endereco", Endereco);
                query.Parameters.AddWithValue("@cep", Cep);
                query.Parameters.AddWithValue("@numero", Numero);
                //query.Parameters.AddWithValue("@materia", Materia);

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

/********************************************************************NUTRICIONISTA**********************************************************************************/

        public string EditarNutricionista(long id)              /*FUNFANDO*/               
        {
            string res = "Salvo com sucesso!";
            try
            {
                con.Open();

                SqlCommand query =
                    new SqlCommand("UPDATE nutricionista SET cpf_usuario = @cpf_usuario, cnpj_instituicao=@cnpj_instituicao WHERE cpf_usuario = @cpf_usuario", con);
                
                query.Parameters.AddWithValue("@cpf_usuario", Cpf);
                query.Parameters.AddWithValue("@cnpj_instituicao", Cnpj);

                query.ExecuteNonQuery();

                query = new SqlCommand("UPDATE usuario SET cpf = @cpf, senha = @senha, nome = @nome, sexo = @sexo,"
                   + "rg = @rg, nascimento = @nascimento, celular = @celular, email = @email, cidade =  @cidade,"
                   + "endereco = @endereco, cep = @cep, numero = @numero WHERE cpf = @cpf", con);

                query.Parameters.AddWithValue("@cpf", Cpf);
                query.Parameters.AddWithValue("@senha", Senha);
                query.Parameters.AddWithValue("@nome", Nome);
                query.Parameters.AddWithValue("@sexo", Sexo);
                query.Parameters.AddWithValue("@rg", Rg);
                query.Parameters.AddWithValue("@nascimento", Nascimento);
                query.Parameters.AddWithValue("@celular", Celular);
                query.Parameters.AddWithValue("@email", Email);
                // query.Parameters.AddWithValue("@foto", Foto); 
                query.Parameters.AddWithValue("@cidade", Cidade);
                query.Parameters.AddWithValue("@endereco", Endereco);
                query.Parameters.AddWithValue("@cep", Cep);
                query.Parameters.AddWithValue("@numero", Numero);

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

/********************************************************************INSTITUICAO**********************************************************************************/

        public string EditarInstituicao(long cnpj)
        {
            string res = "Salvo com sucesso!";
            try
            {
                con.Open();

                SqlCommand query =
                    new SqlCommand("UPDATE instituicao SET cnpj = @cnpj, nomeInst = @nomeInst, telefone = @telefone, cep = @cep, endereco = @endereco, numero = @numero WHERE cnpj = @cnpj", con);

                query.Parameters.AddWithValue("@cnpj", Cnpj);
                query.Parameters.AddWithValue("@nomeInst", NomeInst);
                query.Parameters.AddWithValue("@telefone", Telefone);
                query.Parameters.AddWithValue("@cep", Cep);
                query.Parameters.AddWithValue("@endereco", Endereco);
                query.Parameters.AddWithValue("@numero", Numero);

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