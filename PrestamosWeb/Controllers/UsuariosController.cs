using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrestamosWeb.Models;

namespace PrestamosWeb.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly PrestamosDb _context;

        public UsuariosController(PrestamosDb context)
        {
            _context = context;    
        }
        public IActionResult Index()
        {
            return View(BLL.UsuariosBLL.Listar());
        }
        [HttpPost]
        public JsonResult Guardar(Usuarios nuevo)
        {
            bool resultado = false;
            if (ModelState.IsValid)
            {
                resultado = BLL.UsuariosBLL.Guardar(nuevo);
            }
            return Json(resultado);
        }
        [HttpPost]
        public JsonResult Modificar(Usuarios nuevo)
        {
            var existe = (BLL.UsuariosBLL.Buscar(nuevo.UsuarioId) != null);
            if (existe)
            {
                existe = BLL.UsuariosBLL.Modificar(nuevo);
                return Json(existe);
            }
            else
            {
                return Json(null);
            }
        }
        [HttpGet]
        public JsonResult Buscar(int Id)
        {
            Usuarios nuevo = BLL.UsuariosBLL.Buscar(Id);
            return Json(nuevo);
        }
        [HttpGet]
        public JsonResult Lista(int Id)
        {
            
            return Json(BLL.UsuariosBLL.ListarId(Id));
        }
        [HttpPost]
        public JsonResult Eliminar(Usuarios nuevo)
        {
            var existe = (BLL.UsuariosBLL.Buscar(nuevo.UsuarioId) != null);

            if (existe)
            {
                existe = BLL.UsuariosBLL.Eliminar(nuevo);
                return Json(existe);
            }
            else
            {
                return Json(null);
            }
        }
        [HttpGet]
        public JsonResult LastIndex()
        {
            int id = BLL.UsuariosBLL.Identity();
            if (id > 1 || BLL.UsuariosBLL.Listar().Count > 0)
                ++id;
            return Json(id);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .SingleOrDefaultAsync(m => m.UsuarioId == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,Nombre,Apellido,Email,NombreUsuario,Contraseña,ConfirmContraseña")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios.SingleOrDefaultAsync(m => m.UsuarioId == id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,Nombre,Apellido,Email,NombreUsuario,Contraseña,ConfirmContraseña")] Usuarios usuarios)
        {
            if (id != usuarios.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.UsuarioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .SingleOrDefaultAsync(m => m.UsuarioId == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarios = await _context.Usuarios.SingleOrDefaultAsync(m => m.UsuarioId == id);
            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioId == id);
        }
    }
}
