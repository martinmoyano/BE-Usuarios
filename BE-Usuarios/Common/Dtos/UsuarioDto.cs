using System.ComponentModel.DataAnnotations;

namespace BE_Usuarios.Common.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
