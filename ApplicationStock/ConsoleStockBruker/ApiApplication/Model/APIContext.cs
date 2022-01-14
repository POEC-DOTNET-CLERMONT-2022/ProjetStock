using Microsoft.EntityFrameworkCore;
using ProjectStockLibrary;



namespace ApiApplication.Model
{
    public class APIContext : DbContext
    {
        private string ConnectionString { get; }

        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {
            ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=BDProjectStock;Trusted_Connection=True;MultipleActiveResultSets=true";

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Market> _markets { get; set; }

        public DbSet<Client> _users { get; set; }

        public DbSet<Stock> _stocks { get; set; }

        public DbSet<Order> _orders { get; set; }

        public DbSet<Notification> _notifs { get; set; }


        public DbSet<Address> _addresses { get; set; }



       
    }
}
