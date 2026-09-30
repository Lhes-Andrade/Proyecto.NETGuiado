using Microsoft.AspNetCore.Mvc;
using TiendaWebAndrade.Models;
namespace TiendaWebAndrade.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            var usuarios = new List<Usuario>
            {
                new Usuario {Id = 1, Nombre = "Raquel", Correo = "r@gmail.com", Rol = "Estudiante", Celular = "3001485531", Estado = "A"},
                new Usuario {Id = 2, Nombre = "Juan", Correo = "j@gmail.com", Rol = "Profesor", Celular = "3024285531", Estado = "I"},
                new Usuario {Id = 3, Nombre = "Rodrigo", Correo = "rdg@gmail.com", Rol = "Administrativo", Celular = "3001485531", Estado = "A"},

            };
            return View(usuarios);
        }
    }
}
