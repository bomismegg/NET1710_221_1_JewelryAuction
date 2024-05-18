namespace JewelryAuction.Business.ViewModels.Customer
{

    public class CustomerViewModel
    {
        public int UserId { get; set; }

        public string UserFname { get; set; }

        public string UserLname { get; set; }

        public string UserStreetNo { get; set; }

        public string UserStreetName { get; set; }

        public string UserCity { get; set; }

        public string UserCountry { get; set; }

        public string UserPhoneNo { get; set; }

        public int? UserAdminId { get; set; }
    }

}
