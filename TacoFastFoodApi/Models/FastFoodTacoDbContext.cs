// TacoDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace TacoFastFoodAPI.Models
{
    public class TacoDbContext : DbContext
    {
        public TacoDbContext(DbContextOptions<TacoDbContext> options) : base(options) { }

        public DbSet<Taco> Taco { get; set; }
        public DbSet<Drink> Drink { get; set; }
    }
}