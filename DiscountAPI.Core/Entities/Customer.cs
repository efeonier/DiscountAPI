using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscountAPI.Core.Entities
{
    public class Customer : BaseEntity
    {
        [Required] [MaxLength(200)] public string FirstName { get; set; }
        [Required] [MaxLength(200)] public string LastName { get; set; }
        public string Email { get; set; }
        public int CustomerTypeId { get; set; }
        [ForeignKey("CustomerTypeId")] public CustomerType CustomerType { get; set; }

        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}