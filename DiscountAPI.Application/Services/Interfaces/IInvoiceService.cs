using System.Threading.Tasks;
using DiscountAPI.Application.Model.Request;
using DiscountAPI.Application.Model.Response;
using DiscountAPI.Core.Entities;

namespace DiscountAPI.Application.Services.Interfaces
{
    public interface IInvoiceService : IService<Invoice>
    {
        Task<TotalDiscountResponse> CalculateDiscount(InvoiceRequest invoice);
        Task<InvoiceResponse> CreateInvoice(InvoiceRequest invoice);
    }
}