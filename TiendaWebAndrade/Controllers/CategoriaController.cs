using Microsoft.AspNetCore.Mvc;
using TiendaWebAndrade.Data;
using TiendaWebAndrade.Models;

namespace TiendaWebAndrade.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly TiendaContext _context;
        public CategoriaController(TiendaContext context)
        {
            _context = context;
        }

        // LISTAR LAS CATEGORIAS DE LA BD (READ)
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var categorias = _context.Categorias.ToList();
            return View(categorias);
        }

        // MOSTRAR EL FORMULARIO PARA CREAR UNA CATEGORIA
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // GUARDAR LA NUEVA CATEGORIA EN LA BD (CREATE)
        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // MOSTRAR EL FORMULARIO PARA EDITAR UNA CATEGORIA
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var categoria = _context.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // ACTUALIZAR LA CATEGORIA EN LA BD (UPDATE)
        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                _context.Categorias.Update(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // ELIMINAR UNA CATEGORIA DE LA BD (DELETE)
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var categoria = _context.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }
            // No permitir eliminar si hay productos usando esta categoría
            if (_context.Productos.Any(p => p.CategoriaId == id))
            {
                TempData["Error"] = "No se puede eliminar la categoría porque tiene productos asociados.";
                return RedirectToAction("Index");
            }
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}