using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VRbit.Agendamentos.UI.Sistema.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Cadastro Clientes";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "christianreggiani@hotmail.com";

            return View();
        }
    }
}