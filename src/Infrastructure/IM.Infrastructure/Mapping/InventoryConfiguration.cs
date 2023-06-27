namespace IM.Infrastructure.Mapping;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Inventory;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.HasKey(_ => _.Id);

        builder
            .Property(_ => _.Product)
            .HasMaxLength(100)
            .IsRequired()
            .IsUnicode();

        builder
           .Property(_ => _.Price)
           .IsRequired();
    }
}
