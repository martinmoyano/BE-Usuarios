using BE_Usuarios.Common.Models;
using FluentValidation;

namespace BE_Usuarios.Services
{
    public class UsuarioValidacion : AbstractValidator<Usuario>
    {

        public UsuarioValidacion()
        {
            RuleFor(usuario => usuario.Nombre).Length(2, 30);
            RuleFor(usuario => usuario.Email).EmailAddress();
        }
    }
}
