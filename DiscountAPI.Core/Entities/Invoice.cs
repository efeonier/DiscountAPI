using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscountAPI.Core.Entities
{
    public class Invoice : BaseEntity
    {
        public string InvoiceNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountedTotalAmount { get; set; }
        
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")] public Customer Customer { get; set; }
    }
}