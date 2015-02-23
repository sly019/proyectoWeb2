using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LescaBusiness.Models;

namespace LescaBusiness.Controllers
{
    public class ClientesController : Controller
    {
        private InfoClienteDBContext db = new InfoClienteDBContext();

        // GET: /Clientes/
        public ActionResult Index()
        {
            return View(db.InfoCliente.ToList());
        }

        // GET: /Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoCliente infocliente = db.InfoCliente.Find(id);
            if (infocliente == null)
            {
                return HttpNotFound();
            }
            return View(infocliente);
        }

        // GET: /Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,solicitud,nombreCliente,direccion,contacto,telefono,Enum,volocidadcontratada,cpe")] InfoCliente infocliente)
        {
            if (ModelState.IsValid)
            {
                db.InfoCliente.Add(infocliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(infocliente);
        }

        // GET: /Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoCliente infocliente = db.InfoCliente.Find(id);
            if (infocliente == null)
            {
                return HttpNotFound();
            }
            return View(infocliente);
        }

        // POST: /Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,solicitud,nombreCliente,direccion,contacto,telefono,Enum,volocidadcontratada,cpe")] InfoCliente infocliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(infocliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(infocliente);
        }

        // GET: /Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoCliente infocliente = db.InfoCliente.Find(id);
            if (infocliente == null)
            {
                return HttpNotFound();
            }
            return View(infocliente);
        }

        // POST: /Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InfoCliente infocliente = db.InfoCliente.Find(id);
            db.InfoCliente.Remove(infocliente);
            db.SaveChanges();
            return RedirectToAction("Index");
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
