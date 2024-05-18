namespace JewelryAuction.Business.ViewModels.AuctionRequestDetail
{

    public class AuctionRequestDetailViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal? ProductStartBidAmount { get; set; }

        public decimal? MinBidIncrement { get; set; }

        public int? SellerId { get; set; }
    }
}
