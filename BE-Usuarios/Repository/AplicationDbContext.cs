using BE_Usuarios.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Usuarios.Repository
{
    public partial class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; } 

    }
}
