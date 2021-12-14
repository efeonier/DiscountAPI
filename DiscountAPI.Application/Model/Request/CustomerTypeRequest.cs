using System.ComponentModel.DataAnnotations;

namespace DiscountAPI.Application.Model.Request
{
    public class CustomerTypeRequest
    {
        public int Id { get; set; }
        [Required] public string Type { get; set; }
    }
}