using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppSchool.Controllers
{
    public class AcessoController : Controller
    {
        // GET: Acesso
        public ActionResult Professor()
        {
            return View();
        }
        public ActionResult Nutricionista()
        {
            return View();
        }
        public ActionResult Aluno()
        {
            return View();
        }
        public ActionResult Instituicao()
        {
            return View();
        }

    }
}