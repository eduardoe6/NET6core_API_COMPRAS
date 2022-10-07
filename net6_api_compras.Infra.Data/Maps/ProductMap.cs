using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using net6_api_compras.Domain.Entities;

namespace net6_api_compras.Infra.Data.Maps
{
    public class ProductMAP : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.CodErp).HasColumnName("CodErp");
            builder.Property(x => x.Price).HasColumnName("Price");

            builder.HasMany(x => x.Purchases).WithOne(p => p.Product).HasForeignKey(x => x.ProductId);
        }
    }
}
