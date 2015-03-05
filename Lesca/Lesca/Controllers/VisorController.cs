using Lesca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Lesca.Controllers
{
    public class VisorController : Controller
    {
        private LescaDbContext db = new LescaDbContext();

        // GET: /Visor/
        public ActionResult Index()
        {
            return View();
        }

        
        // GET: /Visor/
        public ActionResult Clients()
        {
            return View(db.Clientes.ToList());
        }


        // GET: /Cliente/Details/5
        public ActionResult DetailsClient(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

       
	}
}