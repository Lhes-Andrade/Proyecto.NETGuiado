using Microsoft.AspNetCore.Mvc;
using TiendaWebAndrade.Data;
using TiendaWebAndrade.Models;

namespace TiendaWebAndrade.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly TiendaContext _context;

        public UsuarioController(TiendaContext context)
        {
            _context = context;
        }

        // LISTAR/TRAER LOS USUARIOS QUE TENGO EN LA BD (READ)
        public IActionResult Index()
        {
            var usuarios = _context.Usuarios.ToList();
            return View(usuarios);
            // SELECT * FROM Usuarios
        }

        // MOSTRAR EL FORMULARIO PARA CREAR UN NUEVO USUARIO
        public IActionResult Create()
        {
            return View();
        }

        // GUARDAR EL NUEVO USUARIO EN LA BD
        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // MOSTRAR EL FORMULARIO PARA EDITAR UN USUARIO ESPECIFICO
        public IActionResult Edit(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // ACTUALIZAR EL USUARIO EN LA BD
        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // ELIMINAR UN USUARIO EN LA BD
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}