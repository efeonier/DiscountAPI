using System.ComponentModel.DataAnnotations;

namespace DiscountAPI.Application.Model.Request
{
    public class DiscountRequest
    {
        public int Id { get; set; }
        [Required] public decimal Percentage { get; set; }
        [Required] public int CustomerTypeId { get; set; }
    }
}