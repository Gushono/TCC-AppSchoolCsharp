using AppSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppSchool.Controllers
{
    public class ListaController : Controller
    {
        public ActionResult Instituicao()
        {
            Listar l = new Listar();
            return View("Instituicao", l.ListarInstituicao());
        }
        public ActionResult Almoco()
        {
            Listar l = new Listar();
            return View("Almoco", l.ListarAlmoco());
        }
        public ActionResult Aluno()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Aluno(long cpf)
        {
            Listar l = new Listar();
            l.Cpf = cpf;
            return View("AlunoLista", l.ListarAluno());
        }
        public ActionResult Professor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Professor(long cpf)
        {
            Listar l = new Listar();
            l.Cpf = cpf;
            return View("ProfessorLista", l.ListarProfessor());
        }
        public ActionResult Nutricionista()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nutricionista(long cpf)
        {
            Listar l = new Listar();
            l.Cpf = cpf;
            return View("NutricionistaLista", l.ListarNutricionista());
        }

        public ActionResult EditarAluno(long id)
        {
            Editar e = new Editar();
            e.buscaAluno(id);
            if (e == null)
                return RedirectToAction("Aluno");
            else
                return View("EditarAluno",e);
        }
        [HttpPost]
        public ActionResult EditarAluno(long id, string rg, int celular, int cep, long cnpj, int numero, int frequencia, int rm, string senha, string nome, string sexo, string email, string endereco, string almoco, string turma, string cidade, DateTime nascimento)
        {
            Editar e = new Editar();

            e.Cpf = id;
            e.Rg = rg;
            e.Celular = celular;
            e.Cep = cep;
            e.Numero = numero;
            e.Frequencia = frequencia;
            e.Rm = rm;
            e.Senha = senha;
            e.Nome = nome;
            e.Sexo = sexo;
            e.Email = email;
            e.Endereco = endereco;
            e.Almoco = almoco;
            e.Turma = turma;
            e.Nascimento = nascimento;
            e.Cidade = cidade;
            e.Cnpj = cnpj;

            TempData["Msg"] = e.EditaAluno(id);
            return RedirectToAction("Principal", "Principal");

        }

        public ActionResult EditarProfessor(long id)
        {
            Editar e = new Editar();
            e.buscaProfessor(id);
            if (e == null)
                return RedirectToAction("Professor");
            else
                return View("EditarProfessor");
        }
        [HttpPost]
        public ActionResult EditarProfessor(long id, string rg, int celular, int cep, long cnpj, int numero, string materia, string senha, string nome, string sexo, string email, string endereco, string cidade, DateTime nascimento)
        {
            Editar e = new Editar();

            e.Senha = senha;
            e.Nome = nome;
            e.Cpf = id;
            e.Rg = rg;
            e.Sexo = sexo;
            e.Nascimento = nascimento;
            e.Celular = celular;
            e.Email = email;
            e.Cidade = cidade;
            e.Cep = cep;
            e.Endereco = endereco;
            e.Numero = numero;
            e.Cnpj = cnpj;
            e.Materia = materia;

            TempData["Msg"] = e.EditarProfessor(id);
            return RedirectToAction("Principal", "Principal");
        }

        public ActionResult EditarNutricionista(long id)
        {
            Editar e = new Editar();
            e.buscaNutricionista(id);
            if (e == null)
                return RedirectToAction("Nutricionista");
            else
                return View("EditarNutricionista");
        }
        [HttpPost]
        public ActionResult EditarNutricionista(long id, string rg, int celular, int cep, long cnpj, int numero, string senha, string nome, string sexo, string email, string endereco, string cidade, DateTime nascimento)
        {
            Editar e = new Editar();

            e.Senha = senha;
            e.Nome = nome;
            e.Cpf = id;
            e.Rg = rg;
            e.Sexo = sexo;
            e.Nascimento = nascimento;
            e.Celular = celular;
            e.Email = email;
            e.Cidade = cidade;
            e.Cep = cep;
            e.Endereco = endereco;
            e.Numero = numero;
            e.Cnpj = cnpj;
          //  e.FotoCardapio = fotoCardapio;

            TempData["Msg"] = e.EditarNutricionista(id);
            return RedirectToAction("Principal", "Principal");
        }

        public ActionResult EditarInstituicao(long id)
        {
            Editar e = new Editar();
            /*e.buscaNutricionista(id);
            if (e == null)
                return RedirectToAction("Nutricionista");
            else*/
                return View("EditarInstituicao");
        }
        [HttpPost]
        public ActionResult EditarInstituicao(int telefone, int cep, long cnpj, int numero, string nomeInst, string endereco)
        {
            Editar e = new Editar();

            e.Telefone = telefone;
            e.Cep = cep;
            e.Endereco = endereco;
            e.Numero = numero;
            e.Cnpj = cnpj;
            e.NomeInst = nomeInst;

            TempData["Msg"] = e.EditarInstituicao(cnpj);
            return RedirectToAction("Principal", "Principal");
        }

        public ActionResult ExcluirAluno(long id)
        { 
            Excluir l = new Excluir();
            l.Cpf = id;

            TempData["Msg"] = l.ExcluirAluno();

            return RedirectToAction("Principal", "Principal");

        }

       public ActionResult ExcluirProfessor(long id)
        {
            Excluir l = new Excluir();
            l.Cpf = id;

            TempData["Msg"] = l.ExcluirProfessor();

            return RedirectToAction("Principal", "Principal");

        }

        public ActionResult ExcluirInstituicao(long id)
        {
            Excluir l = new Excluir();
            l.Cnpj = id; 

            TempData["Msg"] = l.ExcluirInstituicao();

            return RedirectToAction("Principal", "Principal");
        }

        public ActionResult ExcluirNutricionista(long id)
        {
            Excluir l = new Excluir();
            l.Cpf = id;

            TempData["Msg"] = l.ExcluirNutricionista();

            return RedirectToAction("Principal", "Principal");

        }
    }
}