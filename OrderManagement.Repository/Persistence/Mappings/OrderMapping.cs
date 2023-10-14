using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Repository.Persistence.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("OrderId").ValueGeneratedOnAdd();
            builder.Property(x => x.OrderReference).HasColumnName("OrderReference");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
        }
    }
}
