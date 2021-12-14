using System.ComponentModel.DataAnnotations;
using DiscountAPI.Core.Enums;

namespace DiscountAPI.Application.Model.Request
{
    public class CustomerRequest
    {
        public int Id { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Email { get; set; }
        [Required] public CustomerTypes CustomerTypeId { get; set; }
    }
}