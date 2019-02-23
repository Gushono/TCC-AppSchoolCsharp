using AppSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppSchool.Controllers
{
    public class ExcluirController : Controller
    {
 
        public ActionResult ExcluirAluno(long cpf)
        {
            Excluir l = new Excluir();
            l.Cpf = cpf;

            TempData["Msg"] = l.ExcluirAluno();

            return RedirectToAction("Principal");

        }
        public ActionResult ExcluirProfessor(long cpf)
        {
            Excluir l = new Excluir();
            l.Cpf = cpf;

            TempData["Msg"] = l.ExcluirProfessor();

            return RedirectToAction("Principal");

        }

        public ActionResult ExcluirInstituicao(long cnpj)
        {
            Excluir l = new Excluir();
            l.Cnpj = cnpj;

            TempData["Msg"] = l.ExcluirInstituicao();

            return RedirectToAction("ListarInstituicao");

        }

        public ActionResult ExcluirNutricionista(long cpf)
        {
            Excluir l = new Excluir();
            l.Cpf = cpf;

            TempData["Msg"] = l.ExcluirNutricionista();

            return RedirectToAction("ListarNutricionista");

        }
    }
}