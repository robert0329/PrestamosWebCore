using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrestamosWeb.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace PrestamosWeb.Controllers
{
    public class HomeController : Controller
    {
        private PrestamosDb _context;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Usuarios()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuarios user)
        {
            PrestamosDb db = new PrestamosDb();
            var account = db.Usuarios.Where(u => u.NombreUsuario == user.NombreUsuario && u.Contraseña == user.Contraseña).FirstOrDefault();
            if (account != null)
            {
                HttpContext.Session.SetString("UsuarioId", account.UsuarioId.ToString());
                HttpContext.Session.SetString("NombreUsuario", account.NombreUsuario);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.NombreUsuario)
                };

                var Identity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(Identity);

                HttpContext.Authentication.SignInAsync("CookiePolicy", principal);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "El usuario o contraseña incorrecto!!!.");
            }
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Authentication.SignOutAsync("CookiePolicy");
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
