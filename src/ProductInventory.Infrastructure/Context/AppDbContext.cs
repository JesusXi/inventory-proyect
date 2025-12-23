using Microsoft.EntityFrameworkCore;
using ProductInventory.Domain.Entities;
using ProductInventory.Infrastructure.Config;
namespace ProductInventory.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UsersVM> Users => Set<UsersVM>();
        public DbSet<SessionVM> Sessions => Set<SessionVM>();
        public DbSet<InventoryMovementsVM> InventoryMovements => Set<InventoryMovementsVM>();
        public DbSet<InventoryVM> Inventory => Set<InventoryVM>();
        public DbSet<CatProductsVM> CatProducts => Set<CatProductsVM>();
        public DbSet<CatCategoryVM> CatCategory => Set<CatCategoryVM>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new SessionConfig());
            modelBuilder.ApplyConfiguration(new InventoryMovementsConfig());
            modelBuilder.ApplyConfiguration(new InventoryConfig());
            modelBuilder.ApplyConfiguration(new CatCategoryConfig());
            modelBuilder.ApplyConfiguration(new CatCategoryConfig());
        }
    }
}
