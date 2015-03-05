using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesca.Controllers
{
    public class InicioController : Controller
    {
        //
        // GET: /Inicio/
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Operador()
        {
            return View();
        }

        public ActionResult Visor()
        {
            return View();
        }
	}
}