using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lesca.Models;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net.Mime;
using SendGrid;

namespace Lesca.Controllers
{
    public class ClienteController : Controller
    {
        private LescaDbContext db = new LescaDbContext();

        // GET: /Cliente/
        
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(db.Clientes.ToList());
            }
            else
            {
                TempData["notice"] = "Usuario no tiene historial";
                return View(db.Clientes.ToList() );
            }            
        }

        // GET: /Cliente/Details/5
        public ActionResult Details(int? id)
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

        // GET: /Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,solicitud,nombre,direccion,contacto,telefono,Enum,cpe,volocidad,IP_publica,IP_Privada")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();

                var myMessage = new SendGridMessage();

                myMessage.From = new MailAddress("dmora@coopelesca.co.cr"); //ultimo dado

                // Add multiple addresses to the To field.
                List<String> recipients = new List<String>
                {
                    @"Deiber <dmora@coopelesca.co.cr>"
                };
                myMessage.AddTo(recipients);
                myMessage.Subject = "Correo de confirmación";

                myMessage.Text = "Nuevo cliente empresarial creado" + "\n" + "\n" + "Nombre: " + clientes.nombre+ "\n" + "Solicitud #: " + clientes.solicitud + "\n"
                                    + "Direccion: " + clientes.direccion;

                // Create network credentials to access your SendGrid account.
                var username = "sly019";
                var pswd = "demobA1987%";

                var credentials = new NetworkCredential(username, pswd);

                // Create an Web transport for sending email.
                var transportWeb = new Web(credentials);

                // Send the email.
                transportWeb.Deliver(myMessage);
                
                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        // GET: /Cliente/Edit/5
        public ActionResult Edit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,solicitud,nombre,direccion,contacto,telefono,Enum,cpe,volocidad,IP_publica,IP_Privada")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: /Cliente/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: /Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: /Cliente/Delete/5
        [HttpPost]
        public ActionResult Historial(int? id)
        {
            Historial historial = db.Historials.Find(id);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Historial")]
        [ValidateAntiForgeryToken]
        public ActionResult Historial(int id)
        {
            Clientes clientes = db.Clientes.Find(id);
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
