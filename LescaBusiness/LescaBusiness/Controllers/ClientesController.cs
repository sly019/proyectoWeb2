using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LescaBusiness.Models;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using SendGrid;

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

                // Create the email object first, then add the properties.
                var myMessage = new SendGridMessage();

                // Add the message properties.
                myMessage.From = new MailAddress("deivermora19@gmail.com");

                // Add multiple addresses to the To field.
                List<String> recipients = new List<String>
                {
                    @"Deiber <deivermora19@gmail.com>"
                };
                myMessage.AddTo(recipients);
                myMessage.Subject = "Correo de confirmación";

                //Add Text bodies
                myMessage.Text = "Nuevo cliente empresarial creado" + "\n" + "\n" + "Nombre: "+ infocliente.nombreCliente + "\n" + "Solicitud #: " + infocliente.solicitud + "\n" 
                                    + "Direccion: " + infocliente.direccion ;

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
