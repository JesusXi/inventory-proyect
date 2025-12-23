using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Infrastructure.Config
{
    public class UserConfig : IEntityTypeConfiguration<UsersVM>
    {
        public void Configure(EntityTypeBuilder<UsersVM> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedNever();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.User).HasColumnName("User").ValueGeneratedOnAdd();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired();
            builder.Property(u => u.IsActive).IsRequired();
        }
    }
}
