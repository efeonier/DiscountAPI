using System.Collections.Generic;
using System.Threading.Tasks;
using DiscountAPI.Core.Entities;
using DiscountAPI.Core.Repositories;
using DiscountAPI.Infrasturcture.Context;

namespace DiscountAPI.Infrasturcture.Repositories
{
    public class CustomerTypeRepository : Repository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}