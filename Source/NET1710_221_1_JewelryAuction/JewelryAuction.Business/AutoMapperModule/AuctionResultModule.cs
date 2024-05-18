using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.AuctionResult;
using JewelryAuction.Business.ViewModels.AuctionResult;
using JewelryAuction.Data.Models;


namespace JewelryAuction.Business.AutoMapperModule
{

    public static class AuctionResultModule
    {
        public static void ConfigAuctionResultModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<AuctionResult, AuctionResultViewModel>().ReverseMap();
            mc.CreateMap<AuctionResult, CreateAuctionResultRequestModel>().ReverseMap();
            mc.CreateMap<AuctionResult, UpdateAuctionResultRequestModel>().ReverseMap();
        }
    }

}
