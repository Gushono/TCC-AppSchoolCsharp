using AppSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppSchool.Controllers
{
    public class CadastroController : Controller
    {

        public ActionResult CadastroAluno()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastroAluno(long cpf, string rg, int celular, int cep, long cnpj, int numero, int frequencia, int rm, string senha, string nome, string sexo, string email, string endereco, string almoco, string turma, string cidade, DateTime nascimento)
        {

            try
            {
                foreach (string nomeArq in Request.Files)
                {
                    HttpPostedFileBase arqPostado = Request.Files[nomeArq];
                    int tamConteudo = arqPostado.ContentLength; //pega tamanho
                    string tipoArq = arqPostado.ContentType; //pega o tipo

                    //testar extensão da imagem
                    if (tipoArq.IndexOf("jpeg") > 0 || tipoArq.IndexOf("png") > 0)
                    {
                        //converter para bytes
                        byte[] imgBytes = new byte[tamConteudo];
                        arqPostado.InputStream.Read(imgBytes, 0, tamConteudo);
                        Cadastro c = new Cadastro();

                        c.Cpf = cpf;
                        c.Rg = rg;
                        c.Celular = celular;
                        c.Cep = cep;
                        c.Numero = numero;
                        c.Frequencia = frequencia;
                        c.Rm = rm;
                        c.Senha = senha;
                        c.Nome = nome;
                        c.Sexo = sexo;
                        c.Email = email;
                        c.Endereco = endereco;
                        c.Almoco = almoco;
                        c.Turma = turma;
                        c.Nascimento = nascimento;
                        c.Cidade = cidade;
                        c.Cnpj = cnpj;
                        c.Foto = imgBytes;

                        TempData["Msg"] = c.CadastroAlunos();
                        return RedirectToAction("Principal", "Principal");
                    }
                }
            }
            catch (Exception e)
            {
                e.GetType();
            }
            return RedirectToAction("CadastroAluno", "Cadastro");
        }

        public ActionResult PostarCardapio()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostarCardapio(string a = "")
        {

            try
            {
                foreach (string nomeArq in Request.Files)
                {
                    HttpPostedFileBase arqPostado = Request.Files[nomeArq];
                    int tamConteudo = arqPostado.ContentLength; //pega tamanho
                    string tipoArq = arqPostado.ContentType; //pega o tipo

                    //testar extensão da imagem
                    if (tipoArq.IndexOf("jpeg") > 0 || tipoArq.IndexOf("png") > 0)
                    {
                        //converter para bytes
                        byte[] imgBytes = new byte[tamConteudo];
                        arqPostado.InputStream.Read(imgBytes, 0, tamConteudo);
                        Cadastro c = new Cadastro();

                        c.Foto = imgBytes;
                        
                        TempData["Msg"] = c.PostarCardapio();
                        return RedirectToAction("Principal", "Principal");
                    }
                }
            }
            catch (Exception e)
            {
                e.GetType();
            }
            return RedirectToAction("Cadastro", "PostarCardapio");
        }
        public ActionResult CadastroProfessor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastroProfessor(long cpf, string rg, int celular, int cep, int numero, string senha, string materia, string nome, string sexo, string email, string endereco, long cnpj, string cidade, DateTime nascimento)
        {
            foreach (string foto in Request.Files)
            {
                HttpPostedFileBase arqPostado = Request.Files[foto];
                int tamConteudo = arqPostado.ContentLength; //pega tamanho
                string tipoArq = arqPostado.ContentType; //pega o tipo

                //testar extensão da imagem
                if (tipoArq.IndexOf("jpeg") > 0 || tipoArq.IndexOf("png") > 0)
                {
                    //converter para bytes
                    byte[] imgBytes = new byte[tamConteudo];
                    arqPostado.InputStream.Read(imgBytes, 0, tamConteudo);
                    Cadastro c = new Cadastro();

                    c.Cpf = cpf;
                    c.Rg = rg;
                    c.Celular = celular;
                    c.Cep = cep;
                    c.Numero = numero;
                    c.Materia = materia;
                    c.Senha = senha;
                    c.Nome = nome;
                    c.Sexo = sexo;
                    c.Email = email;
                    c.Endereco = endereco;
                    c.Cnpj = cnpj;
                    c.Nascimento = nascimento;
                    c.Cidade = cidade;
                    c.Foto = imgBytes;

                    TempData["Msg"] = c.CadastroProfessor();
                    return RedirectToAction("Principal", "Principal");
                }

            }
            return RedirectToAction("CadastroProfessor", "Cadastro");
        }
        public ActionResult CadastroNutricionista()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastroNutricionista(long cpf, long cnpj, string rg, int celular, int cep, int numero, string senha, string nome, string sexo, string email, string endereco, string cidade, DateTime nascimento)
        {
            foreach (string foto in Request.Files)
            {
                HttpPostedFileBase arqPostado = Request.Files[foto];
                int tamConteudo = arqPostado.ContentLength; //pega tamanho
                string tipoArq = arqPostado.ContentType; //pega o tipo

                //testar extensão da imagem
                if (tipoArq.IndexOf("jpeg") > 0 || tipoArq.IndexOf("png") > 0)
                {
                    //converter para bytes
                    byte[] imgBytes = new byte[tamConteudo];
                    arqPostado.InputStream.Read(imgBytes, 0, tamConteudo);
                    Cadastro c = new Cadastro();

                    c.Cpf = cpf;
                    c.Rg = rg;
                    c.Celular = celular;
                    c.Cep = cep;
                    c.Numero = numero;
                    c.Senha = senha;
                    c.Nome = nome;
                    c.Sexo = sexo;
                    c.Email = email;
                    c.Endereco = endereco;
                    c.Cnpj = cnpj;
                    c.Nascimento = nascimento;
                    c.Cidade = cidade;
                    c.Foto = imgBytes;

                    TempData["Msg"] = c.CadastroNutricionista();
                    return RedirectToAction("Principal", "Principal");
                }

            }
            return RedirectToAction("CadastroNutricionista", "Cadastro");
        }
        public ActionResult CadastroInstituicao()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastroInstituicao(long cnpj, string nomeInst, int telefone, int cep, string endereco, int numero)
        {
            Cadastro c = new Cadastro();

            c.Cnpj = cnpj;
            c.NomeInst = nomeInst;
            c.Cep = cep;
            c.Endereco = endereco;
            c.Numero = numero;
            c.Telefone = telefone;

            TempData["Msg"] = c.CadastroInstituicao();
            if (TempData["Msg"].Equals("Inserido com sucesso!"))
                return RedirectToAction("Principal", "Principal");
            else
                return RedirectToAction("CadastroInstituicao", "Cadastro");
        }

        public ActionResult CadastroSala()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastroSala(string saladeAula)
        {
            Cadastro c = new Cadastro();
            c.SaladeAula = saladeAula;
            TempData["Msg"] = c.CadastroSala();
            if (TempData["Msg"].Equals("Inserido com sucesso!"))
            { 

                return RedirectToAction("Principal", "Principal");
        }else
         return RedirectToAction("CadastroSala", "Cadastro");
    }
        public ActionResult CadastroAulas()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastroAulas(string saladeAula, string materia, string diadasemana)
        {
            Cadastro c = new Cadastro();
            c.SaladeAula = saladeAula;
            c.Materia = materia;
            c.DiaDaSemana = diadasemana;
            TempData["Msg"] = c.CadastroAulas();
            if (TempData["Msg"].Equals("Inserido com sucesso!"))
            {

                return RedirectToAction("Principal", "Principal");
            }
            else
                return RedirectToAction("CadastroSala", "Cadastro");
        }
    }
    }

           