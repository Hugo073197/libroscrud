using CrudEFCoreNet666.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudEFCoreNet666.Datos
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Usuari> Usuari { get; set; }

   
        
    }
}

    