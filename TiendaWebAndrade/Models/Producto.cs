using System.ComponentModel.DataAnnotations;

namespace TiendaWebAndrade.Models
{
    public class Producto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Range(0, 1000000)]
        public double Precio { get; set; }

        [Range(0, 1000)]
        public int Stock { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public double CalcularValorInventario()
        {
            return Precio * Stock;
        }

        public Boolean CalcularStock()
        {
            return Stock > 0 && Categoria != null && Categoria.Estado == "A";
        }

    }
}

