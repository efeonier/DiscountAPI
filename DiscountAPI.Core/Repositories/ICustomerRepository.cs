using System.Threading.Tasks;
using DiscountAPI.Core.Entities;

namespace DiscountAPI.Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetCustomerByName(string name);
        Task<Customer> GetCustomerByEmail(string email);
    }
}