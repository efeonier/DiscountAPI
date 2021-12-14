using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DiscountAPI.Core.Entities;

namespace DiscountAPI.Application.Model.Request
{
    public class InvoiceRequest
    {
        public string InvoiceNumber { get; set; }

        public int CustomerId { get; set; }

        public List<Product> Products { get; set; }
    }
}