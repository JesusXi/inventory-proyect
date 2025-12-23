using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Infrastructure.Config
{
    public class CatProductosConfig : IEntityTypeConfiguration<CatProductsVM>
    {
        public void Configure(EntityTypeBuilder<CatProductsVM> builder)
        {
            builder.ToTable("CatProducts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdCategory).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
        }
    }
}
