using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarErro()
        {
            ViewBag.MensagemErro = "Erro Interno do Servidor";
            return View("Erro");
        }

        
        //public ActionResult MostrarErro()
        //{
        //    ViewBag.MensagemErro = "Erro interno do servidor";
        //    return View("_Erro");
        //}
    }
}