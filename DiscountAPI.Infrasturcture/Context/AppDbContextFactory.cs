using Microsoft.EntityFrameworkCore;

namespace DiscountAPI.Infrasturcture.Context
{
    public class AppDbContextFactory: DesignTimeDbContextFactory<AppDbContext>
    {
        protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
        {
            return new AppDbContext(options);
        }
    }
}
