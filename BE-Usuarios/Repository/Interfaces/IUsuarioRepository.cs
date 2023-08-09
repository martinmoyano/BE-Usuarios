using BE_Usuarios.Common.Models;

namespace BE_Usuarios.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        public Task<List<Usuario>> ObtenerUsuarios();
        public Task<bool> CrearUsuario(Usuario usuario);
        public Task<bool> BorrarUsuario(int id);
        public Task<bool> ModificarUsuario(Usuario usuario);
    }
}
