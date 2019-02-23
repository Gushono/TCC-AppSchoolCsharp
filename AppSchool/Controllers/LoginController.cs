using AppSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppSchool.Controllers
{
    public class LoginController : Controller
    {

        //login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(long cpf, string senha)
        {
            Session["User"] = "deslogado";
            Login u = new Login();
            u.Cpf = cpf;
            u.Senha = senha;

            if (u.Logar())
            {
                Session["User"] = "logado";
                TempData["Msg"] = "Logado com sucesso";
                return RedirectToAction("Principal", "Principal");
            }
            else
                TempData["Msg"] = "Erro ao Logar";
            return View();
        }
       
    }
}

