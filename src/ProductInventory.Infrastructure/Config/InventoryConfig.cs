using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Infrastructure.Config
{
    public class InventoryConfig : IEntityTypeConfiguration<InventoryVM>
    {
        public void Configure(EntityTypeBuilder<InventoryVM> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdProduct).IsRequired();
            builder.Property(x => x.StockMin).IsRequired();
            builder.Property(x => x.StockMax).IsRequired();
            builder.Property(x => x.Stock).IsRequired();
        }
    }
}
