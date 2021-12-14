using DiscountAPI.Application.Services.Interfaces;
using DiscountAPI.Core.Entities;
using DiscountAPI.Core.Repositories;
using DiscountAPI.Core.UnitOfWorks;

namespace DiscountAPI.Application.Services
{
    public class CustomerTypeService:Service<CustomerType>,ICustomerTypeService
    {
        public CustomerTypeService(IUnitOfWork unitOfWork, IRepository<CustomerType> repository) : base(unitOfWork, repository)
        {
        }
    }
}