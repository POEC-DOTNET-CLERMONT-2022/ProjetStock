using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;
using ProjectStockEntity;

namespace ProjectStockRepository.Context
{
    public class SqlDbContext: DbContext
    { 
        private string ConnectionString { get; }

        public SqlDbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            EntityTypeBuilder<UserEntity> entityTypeBuilder = modelBuilder.Entity<UserEntity>();
            EntityTypeBuilder<AddressEntity> addressTypeBuilder = modelBuilder.Entity<AddressEntity>();
            EntityTypeBuilder<MarketEntity> marketTypeBuilder = modelBuilder.Entity<MarketEntity>();
            EntityTypeBuilder<OrderEntity> orderTypeBuilder = modelBuilder.Entity<OrderEntity>();
            EntityTypeBuilder<NotificationEntity> notifTypeBuilder = modelBuilder.Entity<NotificationEntity>();
            EntityTypeBuilder<StockEntity> stockTypeBuilder = modelBuilder.Entity<StockEntity>();
        }

        public override DbSet<TEntity> Set<TEntity>()
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return base.Set<TEntity>();
        }
    }
}