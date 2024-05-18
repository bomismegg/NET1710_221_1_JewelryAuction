namespace JewelryAuction.Business.ViewModels.AuctionSession
{

    public class AuctionSessionViewModel
    {
        public int BidNumber { get; set; }

        public int? BidItemId { get; set; }

        public string BidComment { get; set; }

        public DateTime? BidDate { get; set; }

        public TimeOnly? BidTime { get; set; }

        public int? BidderId { get; set; }

        public int? AuctionId { get; set; }
    }

}
