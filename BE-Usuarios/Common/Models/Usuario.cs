using System.ComponentModel.DataAnnotations;

namespace BE_Usuarios.Common.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}
