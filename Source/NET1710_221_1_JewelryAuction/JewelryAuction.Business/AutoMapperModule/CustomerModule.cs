using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.Customer;
using JewelryAuction.Business.ViewModels.Customer;
using JewelryAuction.Data.Models;


namespace JewelryAuction.Business.AutoMapperModule
{

    public static class CustomerModule
    {
        public static void ConfigCustomerModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Customer, CustomerViewModel>().ReverseMap();
            mc.CreateMap<Customer, CreateCustomerRequestModel>().ReverseMap();
            mc.CreateMap<Customer, UpdateCustomerRequestModel>().ReverseMap();
        }
    }

}
