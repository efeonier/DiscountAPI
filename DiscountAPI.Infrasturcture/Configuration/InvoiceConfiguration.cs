using DiscountAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountAPI.Infrasturcture.Configuration
{
    public class InvoiceConfiguration: IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.DiscountedTotalAmount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.InvoiceNumber).IsRequired().HasMaxLength(20);
        }
    }
}