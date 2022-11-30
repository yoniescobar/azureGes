using EvalTIC.Models;
using Microsoft.EntityFrameworkCore;

namespace EvalTIC.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opcions) : base(opcions)
        {

        }
        //Escribir Modelos
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Rol { get; set; }

    }

}
