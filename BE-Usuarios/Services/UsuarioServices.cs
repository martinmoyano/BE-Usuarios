using BE_Usuarios.Common.Dtos;
using BE_Usuarios.Common.Models;
using BE_Usuarios.Repository.Interfaces;
using BE_Usuarios.Services.Interfaces;
using FluentValidation.Results;
using System.Text.RegularExpressions;

namespace BE_Usuarios.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private IUsuarioRepository _usuarioRepository;
        private List<Usuario> _usuarios;

        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository= usuarioRepository;            
        }

        public async Task<UsuariosDto> ObtenerUsuarios()
        {
            _usuarios = await _usuarioRepository.ObtenerUsuarios().ConfigureAwait(false);

            return await Task.Run(() => new UsuariosDto()
            {
                Usuarios = _usuarios
            });
        }

        
        public async Task<bool> CrearUsuario(UsuarioDto usuarioDto)
        {
            Usuario usuario = new Usuario()
            {
                Id = usuarioDto.Id,
                Nombre = usuarioDto.Nombre,
                Email = usuarioDto.Email,
                FechaCreacion = usuarioDto.FechaCreacion
            };

            var validador = new UsuarioValidacion();
            ValidationResult resultado = validador.Validate(usuario);

            if(resultado.IsValid)
            {
                return await _usuarioRepository.CrearUsuario(usuario);
            }
            else
            {
                return false;
            }

            
        }

        public async Task<bool> BorrarUsuario(int id)
        {
            return await Task.Run(() => _usuarioRepository.BorrarUsuario(id));
        }

        
        public async Task<bool> ModificarUsuario(UsuarioDto usuarioDto)
        {
            Usuario usuario = new Usuario()
            {
                Id = usuarioDto.Id,
                Nombre = usuarioDto.Nombre,
                Email = usuarioDto.Email,
                FechaCreacion = usuarioDto.FechaCreacion
            };

            var validador = new UsuarioValidacion();
            ValidationResult resultado = validador.Validate(usuario);

            if (resultado.IsValid)
            {
                return await _usuarioRepository.ModificarUsuario(usuario);
            }
            else
            {
                return false;
            }
        }
    }
}
