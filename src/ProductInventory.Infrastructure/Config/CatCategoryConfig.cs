using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Infrastructure.Config
{
    public class CatCategoryConfig : IEntityTypeConfiguration<CatCategoryVM>
    {
        public void Configure(EntityTypeBuilder<CatCategoryVM> builder)
        {
            builder.ToTable("CatCategory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Active).IsRequired();
        }
    }
}
