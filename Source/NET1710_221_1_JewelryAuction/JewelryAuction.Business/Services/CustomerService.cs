using Ecommerce.BusinessLogic.RequestModels.Customer;
using JewelryAuction.Business.ViewModels.Customer;

namespace JewelryAuction.Business.Services
{

    public interface ICustomerService
    {
        public CustomerViewModel CreateCustomer(CreateCustomerRequestModel customerCreate);
        public CustomerViewModel UpdateCustomer(UpdateCustomerRequestModel customerUpdate);
        public bool DeleteCustomer(int idTmp);
        public List<CustomerViewModel> GetAll();
        public CustomerViewModel GetById(int idTmp);
    }

    public class CustomerService : ICustomerService
    {

        public CustomerViewModel CreateCustomer(CreateCustomerRequestModel customerCreate)
        {
            throw new NotImplementedException();
        }

        public CustomerViewModel UpdateCustomer(UpdateCustomerRequestModel customerUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<CustomerViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
