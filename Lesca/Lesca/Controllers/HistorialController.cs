using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lesca.Models;

namespace Lesca.Controllers
{
    public class HistorialController : Controller
    {
        private LescaDbContext db = new LescaDbContext();

        // GET: /Historial/
        public ActionResult Index()
        {
            return View(db.Historials.ToList());
        }

        // GET: /Historial/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Historial historial = db.Historials.Find(id);
            Historial historial = db.Historials.FirstOrDefault(x => x.IdCliente == id);
          // Historial historia = db.Historials.Where(c => c.IdCliente == id).ToList();  
          // Historial historia = new { historia = db.Historials.Where(c => c.IdCliente.Equals(i)).ToList() };

            if (historial == null)
            {
                ViewBag.ID = 444;
                return Redirect("/Cliente/Index/444");
            }
            return View(historial);
        }

        // GET: /Historial/Create
        public ActionResult Create(int? id)
        {
            Clientes cliente = db.Clientes.Find(id);
            ViewBag.idCliente = cliente.ID;
            return View();
        }

        // POST: /Historial/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,IdCliente,fecha,DescripFallo")] Historial historial,int id)
        {
            
            if (ModelState.IsValid)
            {
                historial.IdCliente = id;
                db.Historials.Add(historial);
                db.SaveChanges();
                return RedirectToAction("Details/" + historial.IdCliente);
            }

            return View(historial);
        }

        // GET: /Historial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial historial = db.Historials.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            return View(historial);
        }

        // POST: /Historial/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,IdCliente,fecha,DescripFallo")] Historial historial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historial).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/"+ historial.IdCliente);
            }
            return View(historial);
        }

        // GET: /Historial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial historial = db.Historials.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            return View(historial);
        }

        // POST: /Historial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historial historial = db.Historials.Find(id);
            db.Historials.Remove(historial);
            db.SaveChanges();
            return RedirectToAction("Cliente/Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
