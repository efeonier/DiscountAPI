using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscountAPI.Core.Entities
{
    public class CustomerType : BaseEntity
    {
        [Required] public string Type { get; set; }

        public Discount Discount { get; set; }

        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}