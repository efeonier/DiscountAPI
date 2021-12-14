using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscountAPI.Application.Model.Request;
using DiscountAPI.Application.Model.Response;
using DiscountAPI.Application.Services.Interfaces;
using DiscountAPI.Core.Entities;
using DiscountAPI.Core.Enums;
using DiscountAPI.Core.Exceptions;
using DiscountAPI.Core.Repositories;
using DiscountAPI.Core.UnitOfWorks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DiscountAPI.Application.Services
{
    public class InvoiceService : Service<Invoice>, IInvoiceService
    {
        private bool _discountApplied = false;
        private readonly ILogger<InvoiceService> _logger;
        private readonly IMapper _mapper;

        public InvoiceService(IUnitOfWork unitOfWork, ILogger<InvoiceService> logger, IMapper mapper,
            IRepository<Invoice> repository) : base(unitOfWork, repository)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<InvoiceResponse> CreateInvoice(InvoiceRequest invoice)
        {
            TotalDiscountResponse response = await CalculateDiscount(invoice);
            var invoiceEntity = new Invoice()
            {
                TotalAmount = response.TotalAmount,
                CustomerId = invoice.CustomerId,
                InvoiceNumber = invoice.InvoiceNumber,
                DiscountedTotalAmount = response.DiscountedTotalAmount
            };
            await _unitOfWork.Invoices.AddAsync(invoiceEntity);
            var newInvoice =
                await _unitOfWork.Invoices.SingleOrDefaultAsync(x => x.InvoiceNumber == invoice.InvoiceNumber);
            foreach (var item in invoice.Products)
            {
                await _unitOfWork.InvoiceProducts.AddAsync(new InvoiceProducts()
                {
                    InvoiceId = newInvoice.Id,
                    ProductId = item.Id
                });
            }

            var invoiceProduct = await _unitOfWork.InvoiceProducts.Where(x => x.InvoiceId == newInvoice.Id);
            var products =
                await _unitOfWork.Products.Where(x => invoiceProduct.Select(w => w.InvoiceId).Contains(x.Id));
            return new InvoiceResponse()
            {
                DiscountedTotalAmount = newInvoice.DiscountedTotalAmount,
                TotalAmount = newInvoice.TotalAmount,
                Customer = await _unitOfWork.Customers.SingleOrDefaultAsync(x => x.Id == invoice.CustomerId),
                InvoiceNumber = invoice.InvoiceNumber,
                Products = products.ToList()
            };
        }

        private bool CalculateJoinedYear(DateTime date)
        {
            return DateTime.Now.Year - date.Year >= 2 ? true : false;
        }

        public async Task<TotalDiscountResponse> CalculateDiscount(InvoiceRequest invoice)
        {
            try
            {
                decimal discountTotalAmount = 0;
                decimal totalAmount = 0;
                TotalDiscountResponse result = new TotalDiscountResponse();
                var customerInfo = await _unitOfWork.Customers.SingleOrDefaultAsync(x => x.Id == invoice.CustomerId);
                if (customerInfo != null)
                {
                    var discount = await _unitOfWork.Discounts.GetDiscountByType(customerInfo.CustomerTypeId);
                    foreach (var product in invoice.Products)
                    {
                        if (!product.IsGroceries)
                        {
                            if (customerInfo.CustomerTypeId == (int) CustomerTypes.Customer &&
                                CalculateJoinedYear(customerInfo.DateCreated) && !_discountApplied)
                            {
                                discountTotalAmount = ((product.Price * product.Quantity) / 100) * discount.Percentage;
                                _discountApplied = true;
                            }
                            else
                            {
                                discountTotalAmount = ((product.Price * product.Quantity) / 100) * discount.Percentage;
                                _discountApplied = true;
                            }
                        }

                        totalAmount = +product.Price * product.Quantity;
                    }
                }

                if (totalAmount > 100)
                {
                    discountTotalAmount += (totalAmount - ((totalAmount / 100) * 5));
                }

                result.TotalAmount = totalAmount;
                result.DiscountedTotalAmount = discountTotalAmount;
                
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"An Error Occured {JsonConvert.SerializeObject(e)}");
                throw new ApiException(e.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}