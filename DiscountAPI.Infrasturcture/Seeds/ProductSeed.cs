using System;
using DiscountAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountAPI.Infrasturcture.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;

        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = _ids[0],
                    Price = 20,
                    Quantity = 5,
                    IsGroceries = false,
                    ProductName = "Tshirt",
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                },
                new Product
                {
                    Id = _ids[1],
                    Price = 200,
                    Quantity = 50,
                    IsGroceries = false,
                    ProductName = "Nike Ayakkabı",
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                },
                new Product
                {
                    Id = _ids[2],
                    Price = 20,
                    Quantity = 500,
                    IsGroceries = true,
                    ProductName = "Elma",
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                }
            );
        }
    }
}