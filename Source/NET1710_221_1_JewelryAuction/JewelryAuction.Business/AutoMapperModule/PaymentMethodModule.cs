using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.PaymentMethod;
using JewelryAuction.Business.ViewModels.PaymentMethod;
using JewelryAuction.Data.Models;


namespace JewelryAuction.Business.AutoMapperModule
{

    public static class PaymentMethodModule
    {
        public static void ConfigPaymentMethodModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<PaymentMethod, PaymentMethodViewModel>().ReverseMap();
            mc.CreateMap<PaymentMethod, CreatePaymentMethodRequestModel>().ReverseMap();
            mc.CreateMap<PaymentMethod, UpdatePaymentMethodRequestModel>().ReverseMap();
        }
    }

}
