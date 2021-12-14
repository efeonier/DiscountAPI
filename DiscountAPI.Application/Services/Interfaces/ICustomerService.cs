using System.Threading.Tasks;
using DiscountAPI.Core.Entities;

namespace DiscountAPI.Application.Services.Interfaces
{
    public interface ICustomerService : IService<Customer>
    {
        Task<Customer> GetCustomerByName(string name);
    }
}