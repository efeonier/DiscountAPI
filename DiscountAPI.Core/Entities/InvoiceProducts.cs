using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscountAPI.Core.Entities
{
    public class InvoiceProducts
    {
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        [ForeignKey("InvoiceId")]
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }

    }
}