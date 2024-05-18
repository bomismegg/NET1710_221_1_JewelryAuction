namespace Ecommerce.BusinessLogic.RequestModels.AuctionRequestDetail
{
    public class CreateAuctionRequestDetailRequestModel
    {
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal? ProductStartBidAmount { get; set; }

        public decimal? MinBidIncrement { get; set; }

        public int? SellerId { get; set; }
    }
}
