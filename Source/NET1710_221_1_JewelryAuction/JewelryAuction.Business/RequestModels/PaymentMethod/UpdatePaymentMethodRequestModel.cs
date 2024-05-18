namespace Ecommerce.BusinessLogic.RequestModels.PaymentMethod
{
    public class UpdatePaymentMethodRequestModel
    {
        public int PaymentMethodId { get; set; }
        public string PaymentMethodDescription { get; set; }
    }
}
