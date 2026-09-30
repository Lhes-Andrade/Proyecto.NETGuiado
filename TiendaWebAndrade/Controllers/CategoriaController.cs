using Microsoft.AspNetCore.Mvc;
using TiendaWebAndrade.Models;
namespace TiendaWebAndrade.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            var categorias = new List<Categoria>
            { 
                new Categoria {Id = 1, Nombre = "Tecnología", Descripcion = "Productos tecnológicos", Estado = "A"},
                new Categoria {Id = 1, Nombre = "Tecnología", Descripcion = "Productos tecnológicos", Estado = "A"},
                new Categoria {Id = 1, Nombre = "Tecnología", Descripcion = "Productos tecnológicos", Estado = "I"},
            };


            return View(categorias);
        }
    }
}
