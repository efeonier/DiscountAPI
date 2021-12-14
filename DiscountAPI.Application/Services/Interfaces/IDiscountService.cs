using System.Threading.Tasks;
using DiscountAPI.Core.Entities;

namespace DiscountAPI.Application.Services.Interfaces
{
    public interface IDiscountService : IService<Discount>
    {
        Task<Discount> GetDiscountByType(int typeId);
    }
}