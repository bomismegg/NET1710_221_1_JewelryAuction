using Ecommerce.BusinessLogic.RequestModels.PaymentMethod;
using JewelryAuction.Business.ViewModels.PaymentMethod;

namespace JewelryAuction.Business.Services
{

    public interface IPaymentMethodService
    {
        public PaymentMethodViewModel CreatePaymentMethod(CreatePaymentMethodRequestModel paymentmethodCreate);
        public PaymentMethodViewModel UpdatePaymentMethod(UpdatePaymentMethodRequestModel paymentmethodUpdate);
        public bool DeletePaymentMethod(int idTmp);
        public List<PaymentMethodViewModel> GetAll();
        public PaymentMethodViewModel GetById(int idTmp);
    }

    public class PaymentMethodService : IPaymentMethodService
    {
        public PaymentMethodViewModel CreatePaymentMethod(CreatePaymentMethodRequestModel paymentmethodCreate)
        {
            throw new NotImplementedException();
        }

        public PaymentMethodViewModel UpdatePaymentMethod(UpdatePaymentMethodRequestModel paymentmethodUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeletePaymentMethod(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<PaymentMethodViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PaymentMethodViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
