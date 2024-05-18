namespace JewelryAuction.Business.ViewModels.AuctionRequest
{
    public class AuctionRequestViewModel
    {
        public int AucId { get; set; }

        public DateTime? AucStartDate { get; set; }

        public DateTime? AucCloseDate { get; set; }

        public decimal? AucReservePrice { get; set; }

        public DateTime? AucPaymentDate { get; set; }

        public string AucWinnerFname { get; set; }

        public string AucWinnerLname { get; set; }

        public decimal? AucPaymentAmount { get; set; }

        public int? AucItemId { get; set; }

        public int? PaymentMethodId { get; set; }
    }
}
