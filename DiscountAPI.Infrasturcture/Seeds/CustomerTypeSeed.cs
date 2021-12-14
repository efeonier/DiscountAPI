using System;
using DiscountAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountAPI.Infrasturcture.Seeds
{
    public class CustomerTypeSeed : IEntityTypeConfiguration<CustomerType>
    {
        private readonly int[] _ids;

        public CustomerTypeSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<CustomerType> builder)
        {
            builder.HasData(
                new CustomerType()
                {
                    Id = _ids[0],
                    Type = "Employee",
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                },
                new CustomerType()
                {
                    Id = _ids[1],
                    Type = "Affiliate",
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                },
                new CustomerType()
                {
                    Id = _ids[2],
                    Type = "Customer",
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                }
            );
        }
    }
}