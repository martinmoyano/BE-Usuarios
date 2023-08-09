using BE_Usuarios.Common.Dtos;

namespace BE_Usuarios.Services.Interfaces
{
    public interface IUsuarioServices
    {
        public Task<UsuariosDto> ObtenerUsuarios();
        public Task<bool> CrearUsuario(UsuarioDto usuarioDto);
        public Task<bool> BorrarUsuario(int id);
        public Task<bool> ModificarUsuario(UsuarioDto usuarioDto);
    }
}
