using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscountAPI.Core.Entities
{
    public class Discount : BaseEntity
    {
        [Required] public decimal Percentage { get; set; }
        [Required] public int CustomerTypeId { get; set; }
        [ForeignKey("CustomerTypeId")] public CustomerType CustomerType { get; set; }
    }
}