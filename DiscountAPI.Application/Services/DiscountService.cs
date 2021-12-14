using System.Threading.Tasks;
using DiscountAPI.Application.Services.Interfaces;
using DiscountAPI.Core.Entities;
using DiscountAPI.Core.Repositories;
using DiscountAPI.Core.UnitOfWorks;

namespace DiscountAPI.Application.Services
{
    public class DiscountService : Service<Discount>, IDiscountService
    {
        public DiscountService(IUnitOfWork unitOfWork, IRepository<Discount> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Discount> GetDiscountByType(int typeId)
        {
            return await _unitOfWork.Discounts.GetDiscountByType(typeId);
        }
    }
}