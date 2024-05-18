using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.AuctionSession;
using JewelryAuction.Business.ViewModels.AuctionSession;
using JewelryAuction.Data.Models;


namespace JewelryAuction.Business.AutoMapperModule
{

    public static class AuctionSessionModule
    {
        public static void ConfigAuctionSessionModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<AuctionSession, AuctionSessionViewModel>().ReverseMap();
            mc.CreateMap<AuctionSession, CreateAuctionSessionRequestModel>().ReverseMap();
            mc.CreateMap<AuctionSession, UpdateAuctionSessionRequestModel>().ReverseMap();
        }
    }

}
