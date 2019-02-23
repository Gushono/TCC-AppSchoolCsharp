using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace AppSchool.Models
{
    public class RecuperarSenha
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BCD"].ConnectionString);

        public bool testePadrao = false;
        public string nome, email, codigo;
        public long cpf;

        public Boolean recuperaSenha()
        {
            try
            {
                con.Open();
                SqlCommand query =
                   new SqlCommand("SELECT nome, email FROM usuario, aluno WHERE @cpf_usuario = cpf_usuario and cpf = @cpf_usuario", con);
                query.Parameters.AddWithValue("@cpf_usuario", cpf);
                SqlDataReader leitor = query.ExecuteReader();

                //Se o leitor achar linhas no banco entãp
                if (leitor.HasRows)
                {
                    //o teste retorna como verdadeiro
                    testePadrao = true;

                    while (leitor.Read())
                    {
                        email = leitor["email"].ToString();
                        nome = leitor["nome"].ToString();

                    }

                    leitor.Close();

                    //Se o teste for verdadeiro, poderá gerar uma senha, salvá-la no banco e enviar o email
                    //Porém, se o cpf for inválido, o sistema encaminhará direto para o fim, dessa forma, retornando falso
                    if (testePadrao == true)
                    {

                        try
                        {
                            //Criando objeto do banco
                            BancoDeDados bd = new BancoDeDados();
                            //Passa o valor retornado para codigo
                            codigo = bd.confirmaEmail();

                            SqlCommand query2 =
                               new SqlCommand("INSERT INTO esqueciSenha VALUES (@codigo, @cpf)", con);

                            query2.Parameters.AddWithValue("@codigo", codigo);
                            query2.Parameters.AddWithValue("@cpf", cpf);
                            query2.ExecuteNonQuery();

                        }
                        catch (Exception e)
                        {
                            e.GetType();
                        }


                        if (con.State == ConnectionState.Open)
                            con.Close();

                        //Configurando a mensagem
                        MailMessage mail = new MailMessage();
                        //Origem
                        mail.From = new MailAddress("guga_nicgato@hotmail.com");
                        //Destinatário
                        mail.To.Add(email);
                        //Assunto
                        mail.Subject = "AppSchool - Mudança de senha";
                        //Corpo do e-mail
                        mail.Body = "O codigo para sua mudança de senha é: " + codigo;
                        //Configurar o smtp
                        SmtpClient smtpServer = new SmtpClient("smtp.office365.com");
                        //configurou porta
                        smtpServer.Port = 587;
                        //Habilitou o TLS
                        smtpServer.EnableSsl = true;
                        //Configurou usuario e senha p/ logar
                        smtpServer.Credentials = new System.Net.NetworkCredential("email", "blablasenha");  //colocar email certo pra enviar
                        //Envia
                        smtpServer.Send(mail);
                        return testePadrao;
                    }
                }
            }


            catch (Exception ex)
            {
                ex.GetType();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

            }

            return testePadrao;

        }

    }
}