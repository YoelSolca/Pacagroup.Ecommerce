using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pacagroup.Ecommerce.Domain.Entities;

namespace Pacagroup.Ecommerce.Persistence.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.Property(x => x.Name)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(x => x.Description)
                    .HasMaxLength(200)
                    .IsRequired();

            builder.Property(x => x.Percent)
                    .HasPrecision(9, 2)
                    .IsRequired();
        }
    }
}
