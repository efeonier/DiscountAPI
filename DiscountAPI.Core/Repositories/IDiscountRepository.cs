using System.Threading.Tasks;
using DiscountAPI.Core.Entities;

namespace DiscountAPI.Core.Repositories
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        Task<Discount> GetDiscountByType(int typeId);
    }
}