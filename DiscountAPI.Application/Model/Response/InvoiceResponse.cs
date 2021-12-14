using System.Collections.Generic;
using DiscountAPI.Core.Entities;

namespace DiscountAPI.Application.Model.Response
{
    public class InvoiceResponse
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountedTotalAmount { get; set; }
        public List<Product> Products { get; set; }
        public Customer Customer { get; set; }
    }
}