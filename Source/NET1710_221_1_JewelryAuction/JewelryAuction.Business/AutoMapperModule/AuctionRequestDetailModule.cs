using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.AuctionRequestDetail;
using JewelryAuction.Business.ViewModels.AuctionRequestDetail;
using JewelryAuction.Data.Models;


namespace JewelryAuction.Business.AutoMapperModule
{

    public static class AuctionRequestDetailModule
    {
        public static void ConfigAuctionRequestDetailModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<AuctionRequestDetail, AuctionRequestDetailViewModel>().ReverseMap();
            mc.CreateMap<AuctionRequestDetail, CreateAuctionRequestDetailRequestModel>().ReverseMap();
            mc.CreateMap<AuctionRequestDetail, UpdateAuctionRequestDetailRequestModel>().ReverseMap();
        }
    }

}
