using System.Threading.Tasks;
using DiscountAPI.Application.Services.Interfaces;
using DiscountAPI.Core.Entities;
using DiscountAPI.Core.Repositories;
using DiscountAPI.Core.UnitOfWorks;

namespace DiscountAPI.Application.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork, IRepository<Customer> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Customer> GetCustomerByName(string name)
        {
            return await _unitOfWork.Customers.GetCustomerByName(name);
        }
        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await _unitOfWork.Customers.GetCustomerByName(email);
        }
    }
}