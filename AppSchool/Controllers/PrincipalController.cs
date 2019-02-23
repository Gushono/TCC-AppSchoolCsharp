using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AppSchool.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Principal()
        {
            return View();
        }
        //sair
        public ActionResult Sair()
        {                    
            return RedirectToAction("Login", "Login");
        }
        public ActionResult Professor()
        {
            return RedirectToAction("Professor", "Principal");
        }
    }
}