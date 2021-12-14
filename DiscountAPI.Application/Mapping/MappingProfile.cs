using AutoMapper;
using DiscountAPI.Application.Model.Request;
using DiscountAPI.Application.Model.Response;
using DiscountAPI.Core.Entities;

namespace DiscountAPI.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerRequest>().ReverseMap();
            CreateMap<Customer, CustomerResponse>().ReverseMap();

            CreateMap<CustomerType, CustomerTypeRequest>().ReverseMap();
            CreateMap<CustomerType, CustomerTypeResponse>().ReverseMap();

            CreateMap<Discount, DiscountRequest>().ReverseMap();
            CreateMap<Discount, DiscountResponse>().ReverseMap();


            CreateMap<Invoice, InvoiceResponse>().ReverseMap();
            CreateMap<Invoice, InvoiceRequest>().ReverseMap();
        }
    }
}