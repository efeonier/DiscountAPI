using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscountAPI.Core.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsGroceries { get; set; }
    }
}