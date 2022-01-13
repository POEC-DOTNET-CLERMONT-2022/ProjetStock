using Microsoft.EntityFrameworkCore;
using ProjectStockLibrary;

namespace ApiApplicationProjectStock.Model
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {

        }
        public DbSet<Market> _markets { get; set; }

        public DbSet<Client> _users { get; set; }

        public DbSet<Stock> _stocks { get; set; }

        public DbSet<Order> _orders { get; set; }
    }
}
