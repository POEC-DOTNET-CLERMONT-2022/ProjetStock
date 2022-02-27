using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;
using ProjectStockEntity;
using ProjectStockLibrary;

namespace ProjectStockRepository.Context
{
    public class SqlDbContext: DbContext
    { 
        private string ConnectionString { get; }

        public SqlDbContext()
        {
            ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=BDProjectStock;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString);
        }
        public override DbSet<TEntity> Set<TEntity>()
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return base.Set<TEntity>();
        }


        public DbSet<Market> _markets { get; set; }

        public DbSet<Client> _users { get; set; }

        public DbSet<Stock> _stocks { get; set; }

        public DbSet<Order> _orders { get; set; }

        public DbSet<Notification> _notifs { get; set; }


        public DbSet<Address> _addresses { get; set; }



    }
}