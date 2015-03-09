using Lesca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Lesca.Controllers
{
    public class LoginController : Controller
    {
        private LescaDbContext db = new LescaDbContext();
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.Usuarios user)
        {
            if (!ModelState.IsValid) // pendiente validar que se venga el estado por el post
            {
                if (user.password == null || user.userEmail == null)
                {
                    ModelState.AddModelError("", "");
                }
                else
                {
                    if (IsValid(user.userEmail, user.password))
                    {
                        Usuarios usuario = db.Usuarios.FirstOrDefault(u => u.userEmail.Equals(user.userEmail));
                        FormsAuthentication.SetAuthCookie(user.userEmail, false);
                        if (usuario.Enum.ToString() == "Administrador")
                        {
                            return RedirectToAction("Index", "Inicio");
                        }
                        if (usuario.Enum.ToString() == "Operador")
                        {
                            return RedirectToAction("Index", "Operador");
                        }
                        if (usuario.Enum.ToString() == "Visor")
                        {
                            return RedirectToAction("Index", "Visor");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "");
                    }
                }
                
            }
            return View(user);
        }

       
        private bool IsValid(string UserEmail, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();

            bool IsValid = false;
            Usuarios user = db.Usuarios.FirstOrDefault(u => u.userEmail.Equals(UserEmail));

                if (user != null)
                {
                    if (user.password == crypto.Compute(password, user.PasswordSalt))
                    {
                        IsValid = true;
                    }
                }
            return IsValid;
        }
	}
}