using APICatalogo.DAO;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Models
{
    public class CatalogoContext : DbContext
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options)
            :base(options)
        { }

        public DbSet<Catalogo> Catalogos { get; set; }
    }
}
