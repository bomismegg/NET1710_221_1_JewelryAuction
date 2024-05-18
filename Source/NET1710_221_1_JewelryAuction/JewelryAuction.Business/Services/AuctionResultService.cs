using Ecommerce.BusinessLogic.RequestModels.AuctionResult;
using JewelryAuction.Business.ViewModels.AuctionResult;

namespace JewelryAuction.Business.Services
{

    public interface IAuctionResultService
    {
        public AuctionResultViewModel CreateAuctionResult(CreateAuctionResultRequestModel auctionresultCreate);
        public AuctionResultViewModel UpdateAuctionResult(UpdateAuctionResultRequestModel auctionresultUpdate);
        public bool DeleteAuctionResult(int idTmp);
        public List<AuctionResultViewModel> GetAll();
        public AuctionResultViewModel GetById(int idTmp);
    }

    public class AuctionResultService : IAuctionResultService
    {

        public AuctionResultViewModel CreateAuctionResult(CreateAuctionResultRequestModel auctionresultCreate)
        {
            throw new NotImplementedException();
        }

        public AuctionResultViewModel UpdateAuctionResult(UpdateAuctionResultRequestModel auctionresultUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAuctionResult(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<AuctionResultViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AuctionResultViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
