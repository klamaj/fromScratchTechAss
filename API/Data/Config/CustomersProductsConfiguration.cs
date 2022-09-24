using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Config;

public class CustomersProductsConfiguration : IEntityTypeConfiguration<CustomersProducts>
{
    public void Configure(EntityTypeBuilder<CustomersProducts> builder)
    {
        // many-to-many
        builder.HasKey(cp => new { cp.CustomerId, cp.ProductId });
        builder.HasOne(cp => cp.Customer)
            .WithMany(c => c.CustomersProducts)
            .HasForeignKey(cp => cp.CustomerId)
            .IsRequired();
        builder.HasOne(cp => cp.Product)
            .WithMany(p => p.CustomersProducts)
            .HasForeignKey(cp => cp.ProductId)
            .IsRequired();
    }
}
