using System.Linq;
using System.Threading.Tasks;
using DiscountAPI.Core.Entities;
using DiscountAPI.Core.Repositories;
using DiscountAPI.Infrasturcture.Context;
using Microsoft.EntityFrameworkCore;

namespace DiscountAPI.Infrasturcture.Repositories
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository(AppDbContext appContext) : base(appContext)
        {
        }

        public async Task<Discount> GetDiscountByType(int typeId)
        {
            return await _appContext.Discounts.Include(x => x.CustomerType).Where(x => x.CustomerTypeId == typeId)
                .SingleOrDefaultAsync();
        }
    }
}