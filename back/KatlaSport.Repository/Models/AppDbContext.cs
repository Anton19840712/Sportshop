using Microsoft.EntityFrameworkCore;

namespace KatlaSport.Repository.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<SportNutritionClient> SportNutritionClients { get; set; }
    }
}
