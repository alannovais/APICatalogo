using APICatalogo.DAO;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Models
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options)
           : base(options)
        { }

        public DbSet<Login> Logins { get; set; }
    }
}
