using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using DiscountAPI.API.Controllers;
using DiscountAPI.Application.Model.Request;
using DiscountAPI.Application.Model.Response;
using DiscountAPI.Application.Services.Interfaces;
using DiscountAPI.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DiscountAPI.Test
{
    public class InvoiceControllerTest
    {
        private readonly InvoiceController _sut;
        private readonly Mock<IInvoiceService> _invoiceService = new Mock<IInvoiceService>();
        private readonly Mock<ILogger> _logger = new Mock<ILogger>();

        public InvoiceControllerTest()
        {
            _sut = new InvoiceController(_logger.Object, _invoiceService.Object);
        }

        [Fact]
        public async Task GetTotalAmountTest()
        {
            //Arrange

            int userId = 1;
            var invoiceDto = new InvoiceRequest()
            {
                CustomerId = 1,
                InvoiceNumber = "2021000533ABC",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Id = 1,
                        Price = 200,
                        Quantity = 2,
                        IsGroceries = false,
                        ProductName = "Yüzük"
                    }
                }
            };

            var invoice = new TotalDiscountResponse();

            _invoiceService.Setup(x => x.CalculateDiscount(invoiceDto)).ReturnsAsync(invoice);

            // Act
            var returnedCustomer = await _sut.CalculateDiscount(invoiceDto);
            var customer1 = (returnedCustomer.Result as OkObjectResult).Value as Invoice;

            //Assert
            Assert.Equal(userId, customer1.CustomerId);
        }
    }
}