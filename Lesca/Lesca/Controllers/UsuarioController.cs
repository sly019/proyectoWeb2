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
    public class UsuarioController : Controller
    {
        private LescaDbContext db = new LescaDbContext();

        // GET: /Usuario/
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        // GET: /Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: /Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,userEmail,password,Enum, PasswordSalt")] Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
               // db.Usuarios.Add(usuarios);
              //  db.SaveChanges();

                var crypto = new SimpleCrypto.PBKDF2();
                var encrpPass = crypto.Compute(usuarios.password);
                var sysUser = db.Usuarios.Create();

                sysUser.Nombre = usuarios.Nombre;
                sysUser.userEmail = usuarios.userEmail;
                sysUser.password = encrpPass;
                sysUser.Enum = usuarios.Enum;                              
                sysUser.PasswordSalt = crypto.Salt;

                db.Usuarios.Add(sysUser);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(usuarios);
        }

        // GET: /Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: /Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,userEmail,password,Enum, PasswordSalt")] Usuarios usuarios)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            var encrpPass = crypto.Compute(usuarios.password);

            usuarios.password = encrpPass;
            usuarios.PasswordSalt = crypto.Salt;

            if (!ModelState.IsValid)
            {
                
                db.Entry(usuarios).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarios);
        }

        // GET: /Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: /Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
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
