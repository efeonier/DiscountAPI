namespace DiscountAPI.Application.Model.Response
{
    public class DiscountResponse
    {
        public int Id { get; set; }
        public decimal Percentage { get; set; }
        public int CustomerTypeId { get; set; }
    }
}