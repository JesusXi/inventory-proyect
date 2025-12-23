using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductInventory.Domain.Entities;
namespace ProductInventory.Infrastructure.Config
{
    public class SessionConfig : IEntityTypeConfiguration<SessionVM>
    {
        public void Configure(EntityTypeBuilder<SessionVM> builder)
        {
            builder.ToTable("Sessions");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Token).IsRequired().HasMaxLength(512);
            builder.Property(s => s.CreatedAt).IsRequired();
            builder.Property(s => s.ExpiresAt).IsRequired();
            builder.HasOne<UsersVM>().WithMany().HasForeignKey(s => s.UserId);
        }
    }
}
