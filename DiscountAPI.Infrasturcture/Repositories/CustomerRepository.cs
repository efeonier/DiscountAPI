using System.Linq;
using System.Threading.Tasks;
using DiscountAPI.Core.Entities;
using DiscountAPI.Core.Repositories;
using DiscountAPI.Infrasturcture.Context;
using Microsoft.EntityFrameworkCore;

namespace DiscountAPI.Infrasturcture.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext appContext) : base(appContext)
        {
        }

        public async Task<Customer> GetCustomerByName(string name)
        {
            return await _appContext.Customers.FirstOrDefaultAsync(x => x.FirstName == name);
        }
    }
}