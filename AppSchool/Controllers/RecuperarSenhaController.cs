using AppSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppSchool.Controllers
{
    public class RecuperarSenhaController : Controller
    {

        public ActionResult RecuperarSenha()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RecuperarSenha(long cpf, string codigo)
        {
            RecuperarSenha r = new RecuperarSenha();
            r.cpf = cpf;
            r.codigo = codigo;
            r.recuperaSenha();
            if (r.recuperaSenha() == true)
            {
                BancoDeDados b = new BancoDeDados();
                b.atualizaSenha();
                return RedirectToAction("Login", "Login");
            }
            else
            {
                TempData["Msg"] = "Erro ao recuperar a senha";
                return RedirectToAction("RecuperarSenha", "RecuperarSenha");
            }

        }
    }
}