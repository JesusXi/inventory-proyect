using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Infrastructure.Config
{
    public class InventoryMovementsConfig : IEntityTypeConfiguration<InventoryMovementsVM>
    {
        public void Configure(EntityTypeBuilder<InventoryMovementsVM> builder)
        {
            builder.ToTable("InventoryMovements");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdProduct).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Motion).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
        }
    }
}
