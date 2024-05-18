using Ecommerce.BusinessLogic.RequestModels.AuctionSession;
using JewelryAuction.Business.ViewModels.AuctionSession;

namespace JewelryAuction.Business.Services
{

    public interface IAuctionSessionService
    {
        public AuctionSessionViewModel CreateAuctionSession(CreateAuctionSessionRequestModel auctionsessionCreate);
        public AuctionSessionViewModel UpdateAuctionSession(UpdateAuctionSessionRequestModel auctionsessionUpdate);
        public bool DeleteAuctionSession(int idTmp);
        public List<AuctionSessionViewModel> GetAll();
        public AuctionSessionViewModel GetById(int idTmp);
    }

    public class AuctionSessionService : IAuctionSessionService
    {

        public AuctionSessionViewModel CreateAuctionSession(CreateAuctionSessionRequestModel auctionsessionCreate)
        {
            throw new NotImplementedException();
        }

        public AuctionSessionViewModel UpdateAuctionSession(UpdateAuctionSessionRequestModel auctionsessionUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAuctionSession(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<AuctionSessionViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AuctionSessionViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
