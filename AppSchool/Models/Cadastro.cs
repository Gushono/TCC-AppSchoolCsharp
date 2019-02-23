using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AppSchool.Models
{

    public class Cadastro
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BCD"].ConnectionString);

        private int celular, cep, numero, frequencia, rm, telefone, ordemaula;
        private String senha, nome, nomeInst, sexo, email, endereco, almoco, turma, cidade, materia, rg, saladeAula, diadasemana;
        private DateTime nascimento;
        private Byte[] foto, fotoCardapio;
        private long cpf, cnpj;

        public long Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }
        public String Rg
        {
            get { return rg; }
            set { rg = value; }
        }
        public String DiaDaSemana
        {
            get { return diadasemana; }
            set { diadasemana = value; }
        }
        public String SaladeAula
        {
            get { return saladeAula; }
            set { saladeAula = value; }
        }

        public int Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        public int OrdemAula
        {
            get { return ordemaula; }
            set { ordemaula = value; }
        }
        public int Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        [DisplayName("CEP")]
        public int Cep
        {
            get { return cep; }
            set { cep = value; }
        }
        [DisplayName("Número da casa/apto")]
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
        [DisplayName("CNPJ")]
        public long Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }
        public String Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        [DisplayName("Nome da instituição")]
        public String NomeInst
        {
            get { return nomeInst; }
            set { nomeInst = value; }
        }
        public String Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }
        [DisplayName("Endereço")]
        public String Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        public String Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public String Almoco
        {
            get { return almoco; }
            set { almoco = value; }
        }
        public String Turma
        {
            get { return turma; }
            set { turma = value; }
        }
        public String Materia
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

        public string CadastroAlunos()
        {
            string res = "Inserido com sucesso!";
            try
            {
                con.Open();

                SqlCommand query =
                    new SqlCommand("INSERT INTO usuario VALUES(@cpf,@senha,@nome,@sexo,@rg,@nascimento,@celular,@email,@foto,@cidade,@endereco,@cep,@numero)",
                        con);
                query.Parameters.AddWithValue("@cpf", Cpf);
                query.Parameters.AddWithValue("@senha", Senha);
                query.Parameters.AddWithValue("@nome", Nome);
                query.Parameters.AddWithValue("@sexo", Sexo);
                query.Parameters.AddWithValue("@rg", Rg);
                query.Parameters.AddWithValue("@nascimento", Nascimento);
                query.Parameters.AddWithValue("@celular", Celular);
                query.Parameters.AddWithValue("@email", Email);
                query.Parameters.AddWithValue("@foto", Foto); 
                query.Parameters.AddWithValue("@cidade", Cidade);
                query.Parameters.AddWithValue("@endereco", Endereco);
                query.Parameters.AddWithValue("@cep", Cep);
                query.Parameters.AddWithValue("@numero", Numero);

                query.ExecuteNonQuery();

                query =
                    new SqlCommand("INSERT INTO aluno VALUES(@frequencia,@almoco,@rm,@cpf_usuario,@cnpj_instituicao,@turma_saladeAula)",
                        con);
                query.Parameters.AddWithValue("@frequencia", Frequencia);
                query.Parameters.AddWithValue("@almoco", Almoco);
                query.Parameters.AddWithValue("@turma_saladeAula", Turma);
                query.Parameters.AddWithValue("@rm", Rm);
                query.Parameters.AddWithValue("@cpf_usuario", Cpf);
                query.Parameters.AddWithValue("@cnpj_instituicao", Cnpj);

                query.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                res = e.Message;
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return res;
        }

        public string PostarCardapio()
        {
            string res = "Inserido com sucesso!";
            try
            {
                con.Open();

                SqlCommand query =
                    new SqlCommand("UPDATE cardapio set @fotoCardapio = fotoCardapio", con);
                query.Parameters.AddWithValue("@fotoCardapio", Foto);
              

                query.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                res = e.Message;
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return res;
        }

        public string CadastroProfessor()
        {
            string res = "Inserido com sucesso!";
            try
            {
                con.Open();

                SqlCommand query =
                    new SqlCommand("INSERT INTO usuario VALUES(@cpf,@senha,@nome,@sexo,@rg,@nascimento,@celular,@email,@foto,@cidade,@endereco,@cep,@numero)",
                        con);
                query.Parameters.AddWithValue("@cpf", Cpf);
                query.Parameters.AddWithValue("@senha", Senha);
                query.Parameters.AddWithValue("@nome", Nome);
                query.Parameters.AddWithValue("@sexo", Sexo);
                query.Parameters.AddWithValue("@rg", Rg);
                query.Parameters.AddWithValue("@nascimento", Nascimento);
                query.Parameters.AddWithValue("@celular", Celular);
                query.Parameters.AddWithValue("@email", Email);
                query.Parameters.AddWithValue("@foto", Foto);
                query.Parameters.AddWithValue("@cidade", Cidade);
                query.Parameters.AddWithValue("@endereco", Endereco);
                query.Parameters.AddWithValue("@cep", Cep);
                query.Parameters.AddWithValue("@numero", Numero);

                query.ExecuteNonQuery();

                query =
                    new SqlCommand("INSERT INTO professor VALUES(@materia,@cpf_usuario,@cnpj_instituicao)",
                        con);
                query.Parameters.AddWithValue("@materia", Materia);
                query.Parameters.AddWithValue("@cpf_usuario", Cpf);
                query.Parameters.AddWithValue("@cnpj_instituicao", Cnpj);

                query.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                res = e.Message;
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return res;
        }

        public string CadastroInstituicao()
        {
            string res = "Inserido com sucesso!";
            try
            {
                con.Open();

                SqlCommand query =
                    new SqlCommand("INSERT INTO instituicao VALUES(@cnpj,@nomeInst,@telefone,@cep,@endereco,@numero)",
                        con);
                query.Parameters.AddWithValue("@cnpj", Cnpj);
                query.Parameters.AddWithValue("@nomeInst", nomeInst);
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

            if (con.State == ConnectionState.Open)
                con.Close();

            return res;
        }

        public string CadastroNutricionista()
        {
            string res = "Inserido com sucesso!";
            try
            {
                con.Open();

                SqlCommand query =
                    new SqlCommand("INSERT INTO usuario VALUES(@cpf,@senha,@nome,@sexo,@rg,@nascimento,@celular,@email,@foto,@cidade,@endereco,@cep,@numero)",
                        con);
                query.Parameters.AddWithValue("@cpf", Cpf);
                query.Parameters.AddWithValue("@senha", Senha);
                query.Parameters.AddWithValue("@nome", Nome);
                query.Parameters.AddWithValue("@sexo", Sexo);
                query.Parameters.AddWithValue("@rg", Rg);
                query.Parameters.AddWithValue("@nascimento", Nascimento);
                query.Parameters.AddWithValue("@celular", Celular);
                query.Parameters.AddWithValue("@email", Email);
                query.Parameters.AddWithValue("@foto", Foto);
                query.Parameters.AddWithValue("@cidade", Cidade);
                query.Parameters.AddWithValue("@endereco", Endereco);
                query.Parameters.AddWithValue("@cep", Cep);
                query.Parameters.AddWithValue("@numero", Numero);

                query.ExecuteNonQuery();

                query =
                    new SqlCommand("INSERT INTO nutricionista VALUES(@cpf_usuario,@cnpj_instituicao)",
                        con);
                query.Parameters.AddWithValue("@cpf_usuario", Cpf);
                query.Parameters.AddWithValue("@cnpj_instituicao", Cnpj);

                query.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                res = e.Message;
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return res;
        }
        public string CadastroSala()
        {
            string res = "Inserido com sucesso!";
            try
            {
                con.Open();

                SqlCommand query =
                    new SqlCommand("INSERT INTO salas VALUES(@saladeAula)",
                        con);
                query.Parameters.AddWithValue("@saladeAula", SaladeAula);

                query.ExecuteNonQuery();               
            }
            catch (Exception e)
            {
                res = e.Message;
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return res;
        }
        public string CadastroAulas()
        {
            string res = "Inserido com sucesso!";
            try
            {
                con.Open();
                int i = 1;
                string segunda = "Segunda";
                string terca = "Terça";
                string quarta = "Quarta";
                string quinta = "Quinta";
                string sexta = "Sexta";

                    while (i < 7)
                    {
                   var materia2 = Materia;
                        DiaDaSemana = segunda;
                        SqlCommand query =
                            new SqlCommand("INSERT INTO aulas VALUES(@ordemAula,@diaDaSemana,@materia,@aula_saladeAula)",
                                con);
                        query.Parameters.AddWithValue("@ordemAula", i);
                        query.Parameters.AddWithValue("@diaDaSemana", DiaDaSemana);
                        query.Parameters.AddWithValue("@materia", Materia);
                        query.Parameters.AddWithValue("@aula_saladeAula", SaladeAula);
                        query.ExecuteNonQuery();
                        i++;
                    }
                while (i < 7)
                {
                    DiaDaSemana = terca;
                    SqlCommand query =
                        new SqlCommand("INSERT INTO aulas VALUES(@ordemAula,@diaDaSemana,@materia,@aula_saladeAula)",
                            con);
                    query.Parameters.AddWithValue("@ordemAula", i);
                    query.Parameters.AddWithValue("@diaDaSemana", DiaDaSemana);
                    query.Parameters.AddWithValue("@materia", Materia);
                    query.Parameters.AddWithValue("@aula_saladeAula", SaladeAula);
                    query.ExecuteNonQuery();
                    i++;
                }
                while (i < 7)
                {
                    DiaDaSemana = quarta;
                    SqlCommand query =
                        new SqlCommand("INSERT INTO aulas VALUES(@ordemAula,@diaDaSemana,@materia,@aula_saladeAula)",
                            con);
                    query.Parameters.AddWithValue("@ordemAula", i);
                    query.Parameters.AddWithValue("@diaDaSemana", DiaDaSemana);
                    query.Parameters.AddWithValue("@materia", Materia);
                    query.Parameters.AddWithValue("@aula_saladeAula", SaladeAula);
                    query.ExecuteNonQuery();
                    i++;
                }
                while (i < 7)
                {
                    DiaDaSemana = quinta;
                    SqlCommand query =
                        new SqlCommand("INSERT INTO aulas VALUES(@ordemAula,@diaDaSemana,@materia,@aula_saladeAula)",
                            con);
                    query.Parameters.AddWithValue("@ordemAula", i);
                    query.Parameters.AddWithValue("@diaDaSemana", DiaDaSemana);
                    query.Parameters.AddWithValue("@materia", Materia);
                    query.Parameters.AddWithValue("@aula_saladeAula", SaladeAula);
                    query.ExecuteNonQuery();
                    i++;
                }
                while (i < 7)
                {
                    DiaDaSemana = sexta;
                    SqlCommand query =
                        new SqlCommand("INSERT INTO aulas VALUES(@ordemAula,@diaDaSemana,@materia,@aula_saladeAula)",
                            con);
                    query.Parameters.AddWithValue("@ordemAula", i);
                    query.Parameters.AddWithValue("@diaDaSemana", DiaDaSemana);
                    query.Parameters.AddWithValue("@materia", Materia);
                    query.Parameters.AddWithValue("@aula_saladeAula", SaladeAula);
                    query.ExecuteNonQuery();
                    i++;
                }
            }
            catch (Exception e)
            {
                res = e.Message;
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            return res;
        }

    }
}