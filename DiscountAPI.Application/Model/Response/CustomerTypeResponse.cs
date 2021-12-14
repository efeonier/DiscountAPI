using DiscountAPI.Core.Entities;

namespace DiscountAPI.Application.Model.Response
{
    public class CustomerTypeResponse
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public Discount Discount { get; set; }
    }
}