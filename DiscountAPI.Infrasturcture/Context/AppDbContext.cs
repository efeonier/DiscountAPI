using DiscountAPI.Core.Entities;
using DiscountAPI.Core.UnitOfWorks;
using DiscountAPI.Infrasturcture.Configuration;
using DiscountAPI.Infrasturcture.Seeds;
using Microsoft.EntityFrameworkCore;

namespace DiscountAPI.Infrasturcture.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InvoiceProducts> InvoiceProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceProductsConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] {1, 2, 3}));
            modelBuilder.ApplyConfiguration(new CustomerSeed(new int[] {1, 2, 3}));
            modelBuilder.ApplyConfiguration(new CustomerTypeSeed(new int[] {1, 2, 3}));
            modelBuilder.ApplyConfiguration(new DiscountSeed(new int[] {1, 2, 3}));
        }
    }
}