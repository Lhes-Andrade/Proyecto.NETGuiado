using System.ComponentModel.DataAnnotations;

namespace TiendaWebAndrade.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }

        [RegularExpression(@"^3\d{9}$", ErrorMessage = "El celular debe tener 10 dígitos y empezar por 3")]
        public string Celular { get; set; }
    }
}
