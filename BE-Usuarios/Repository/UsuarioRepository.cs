using BE_Usuarios.Common.Models;
using BE_Usuarios.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BE_Usuarios.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private AplicationDbContext _context;
        private List<Usuario> _usuarios = new List<Usuario>();

        public UsuarioRepository(AplicationDbContext context)
        {
            _context = context; 
        }        

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            _usuarios.Clear();
            
            _usuarios = _context.Usuario.ToList();
            
            return await Task.Run(() => _usuarios);
        }

        public async Task<bool> CrearUsuario(Usuario usuario)
        {
            Usuario usuarioBD = new Usuario()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                FechaCreacion = usuario.FechaCreacion
            };

            _context.Usuario.Add(usuarioBD);
            _context.SaveChanges();

            return await Task.Run(() => true);
        }

        public async Task<bool> BorrarUsuario(int id)
        {            
            var lista = _context.Usuario.Where(us => us.Id == id);

            foreach (var item in lista)
            {
                _context.Usuario.Remove(item);
            }
            
            _context.SaveChanges();

            return await Task.Run(() => true);
        }

        public async Task<bool> ModificarUsuario(Usuario usuario)
        {
            Usuario usuarioDB = new Usuario()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                FechaCreacion = usuario.FechaCreacion
            };

            _context.Usuario.Update(usuarioDB);
            _context.SaveChanges();

            return await Task.Run(() => true);
        }
    }
}
