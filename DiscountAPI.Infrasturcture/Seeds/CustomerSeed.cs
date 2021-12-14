using System;
using DiscountAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountAPI.Infrasturcture.Seeds
{
    public class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        private readonly int[] _ids;

        public CustomerSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer()
                {
                    Id = _ids[0],
                    FirstName = "Efe",
                    LastName = "Önier",
                    Email = "efe_onier@windowslive.com",
                    CustomerTypeId = 1,
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                },
                new Customer()
                {
                    Id = _ids[1],
                    FirstName = "Obefemi",
                    LastName = "Martins",
                    Email = "obefemi@martins.com",
                    CustomerTypeId = 2,
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                },
                new Customer()
                {
                    Id = _ids[2],
                    FirstName = "Ricky Jade",
                    LastName = "Jones",
                    Email = "ricky_jade@jones.com",
                    CustomerTypeId = 3,
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                }
            );
        }
    }
}