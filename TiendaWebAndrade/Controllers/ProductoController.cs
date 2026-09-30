using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using TiendaWebAndrade.Data;
using TiendaWebAndrade.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TiendaWebAndrade.Controllers
{
    public class ProductoController : Controller
    {
        private readonly TiendaContext _context;
        public ProductoController(TiendaContext context)
        {
            _context = context;
        }
        // LISTAR/TRAER LOS PRODUCTOS QUE TENGO EN LA BD (READ-LEER/CONSULTAR)
        public IActionResult Index()
        {
            var productos = _context.Productos
                .Include(p => p.Categoria)
                .ToList();
            return View(productos);
            //Select * from Productos
            //join categorias on Productos.CategoriaId = Categorias.Id
        }

        // MOSTRAR EL FORMULARIO PARA CREAR UN NUEVO PRODUCTO
        public IActionResult Create()
        {
            return View();
        }

        // GUARDAR EL NUEVO PRODUCTO EN LA BD
        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // MOSTRAR EL FORMULARIO PARA EDITAR UN PRODUCTO ESPECIFICO
        public IActionResult Edit(int id)
        {
            var producto = _context.Productos.Find(id);
            return View(producto);
        }

        // ACTUALIZAR EL PRODUCTO EN LA BD
        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Update(producto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // ELIMINAR UN PRODUCTO EN LA BD
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var producto = _context.Productos.Find(id);
            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}