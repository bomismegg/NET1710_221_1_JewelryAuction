using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.AuctionRequest;
using JewelryAuction.Business.ViewModels.AuctionRequest;
using JewelryAuction.Data.Models;


namespace JewelryAuction.Business.AutoMapperModule
{

    public static class AuctionRequestModule
    {
        public static void ConfigAuctionRequestModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<AuctionRequest, AuctionRequestViewModel>().ReverseMap();
            mc.CreateMap<AuctionRequest, CreateAuctionRequestRequestModel>().ReverseMap();
            mc.CreateMap<AuctionRequest, UpdateAuctionRequestRequestModel>().ReverseMap();
        }
    }

}
