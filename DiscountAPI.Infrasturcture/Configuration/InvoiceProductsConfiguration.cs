using DiscountAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountAPI.Infrasturcture.Configuration
{
    public class InvoiceProductsConfiguration: IEntityTypeConfiguration<InvoiceProducts>
    {
        public void Configure(EntityTypeBuilder<InvoiceProducts> builder)
        {
            builder.ToTable("InvoiceProducts");
            builder.HasNoKey();
        }
    }
}