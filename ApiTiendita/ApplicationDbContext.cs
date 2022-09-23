using ApiTiendita.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiTiendita
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //Crea la tabla Productos
        public DbSet<Producto> Producto { get; set; }

        public DbSet<Proovedor> Proovedor { get; set; }

    }
}
