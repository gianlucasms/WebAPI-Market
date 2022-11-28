using Microsoft.EntityFrameworkCore;

namespace WebAPI_market.Model
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        {
            Database.EnsureCreated();   
        }
        public DbSet<Market> Markets { get; set; }

    }
}
