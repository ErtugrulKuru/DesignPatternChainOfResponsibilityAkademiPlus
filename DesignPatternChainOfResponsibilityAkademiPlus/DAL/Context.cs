using Microsoft.EntityFrameworkCore;

namespace DesignPatternChainOfResponsibilityAkademiPlus.DAL
{
    public class Context:DbContext
    {   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JH4NS85;initial catalog=AkademiPlusChainOfRespDb;integrated security=true");
        }
        public DbSet<CustomerProcess> CustomerProcesss { get; set; }
    }
}
