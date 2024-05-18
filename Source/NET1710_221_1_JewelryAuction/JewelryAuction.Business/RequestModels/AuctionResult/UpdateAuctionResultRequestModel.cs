namespace Ecommerce.BusinessLogic.RequestModels.AuctionResult
{
    public class UpdateAuctionResultRequestModel
    {
        public int UserId { get; set; }

        public long? Payment { get; set; }

        public int AucId { get; set; }
    }
}
