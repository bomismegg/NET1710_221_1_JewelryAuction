using Ecommerce.BusinessLogic.RequestModels.AuctionRequest;
using JewelryAuction.Business.ViewModels.AuctionRequest;

namespace JewelryAuction.Business.Services
{

    public interface IAuctionRequestService
    {
        public AuctionRequestViewModel CreateAuctionRequest(CreateAuctionRequestRequestModel auctionrequestCreate);
        public AuctionRequestViewModel UpdateAuctionRequest(UpdateAuctionRequestRequestModel auctionrequestUpdate);
        public bool DeleteAuctionRequest(int idTmp);
        public List<AuctionRequestViewModel> GetAll();
        public AuctionRequestViewModel GetById(int idTmp);
    }

    public class AuctionRequestService : IAuctionRequestService
    {

        public AuctionRequestViewModel CreateAuctionRequest(CreateAuctionRequestRequestModel auctionrequestCreate)
        {
            throw new NotImplementedException();
        }

        public AuctionRequestViewModel UpdateAuctionRequest(UpdateAuctionRequestRequestModel auctionrequestUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAuctionRequest(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<AuctionRequestViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AuctionRequestViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
