using System.Threading.Tasks;
using DiscountAPI.Core.Entities;

namespace DiscountAPI.Application.Services.Interfaces
{
    public interface IInvoiceService : IService<Invoice>
    {
        Task<Invoice> CalculateDiscount(Invoice invoice);
    }
}