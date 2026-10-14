using Microsoft.AspNetCore.Mvc;
using TiendaWebAndrade.Data;

namespace TiendaWebAndrade.Controllers
{
        public class LoginController : Controller
        {
            private readonly TiendaContext _context;
            public LoginController(TiendaContext context)
            {
                _context = context;
            }
            public IActionResult Index()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Index(string correo, string clave)
            {
                var usuario = _context.Usuarios
                    .FirstOrDefault(u => u.Correo == correo && u.Rol == clave);
                if (usuario != null)
            {
                // En la variable Session no guardamos lo que recibimos en Index por parámetro (Correo, Clave).
                // Creo la variable Session para guardar el nombre del usuario
                HttpContext.Session.SetString("Usuario", usuario.Nombre);
                // En la misma variable Session estoy guardando el rol
                HttpContext.Session.SetString("Rol", usuario.Rol);
                    //A donde irá cuando se loguea, aquí se indica
                    return RedirectToAction("Index", "Producto");
                }
                ViewBag.Error = "Credenciales incorrectas";
                return View();
            }
            public IActionResult Logout()
            {
                //Destruye la variable Session, y redirecciona al index del login (salida)
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Login");
            }
        }
    }
