using System;
using DiscountAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountAPI.Infrasturcture.Seeds
{
    public class DiscountSeed : IEntityTypeConfiguration<Discount>
    {
        private readonly int[] _ids;

        public DiscountSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasData(
                new Discount()
                {
                    Id = _ids[0],
                    CustomerTypeId = 1,
                    Percentage = 30,
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                },
                new Discount()
                {
                    Id = _ids[1],
                    CustomerTypeId = 2,
                    Percentage = 10,
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                },
                new Discount()
                {
                    Id = _ids[2],
                    CustomerTypeId = 3,
                    Percentage = 5,
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                }
            );
        }
    }
}