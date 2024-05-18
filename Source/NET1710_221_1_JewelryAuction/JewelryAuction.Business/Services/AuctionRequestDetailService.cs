using Ecommerce.BusinessLogic.RequestModels.AuctionRequestDetail;
using JewelryAuction.Business.ViewModels.AuctionRequestDetail;

namespace JewelryAuction.Business.Services
{

    public interface IAuctionRequestDetailService
    {
        public AuctionRequestDetailViewModel CreateAuctionRequestDetail(CreateAuctionRequestDetailRequestModel auctionrequestdetailCreate);
        public AuctionRequestDetailViewModel UpdateAuctionRequestDetail(UpdateAuctionRequestDetailRequestModel auctionrequestdetailUpdate);
        public bool DeleteAuctionRequestDetail(int idTmp);
        public List<AuctionRequestDetailViewModel> GetAll();
        public AuctionRequestDetailViewModel GetById(int idTmp);
    }

    public class AuctionRequestDetailService : IAuctionRequestDetailService
    {

        public AuctionRequestDetailViewModel CreateAuctionRequestDetail(CreateAuctionRequestDetailRequestModel auctionrequestdetailCreate)
        {
            throw new NotImplementedException();
        }

        public AuctionRequestDetailViewModel UpdateAuctionRequestDetail(UpdateAuctionRequestDetailRequestModel auctionrequestdetailUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAuctionRequestDetail(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<AuctionRequestDetailViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AuctionRequestDetailViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
