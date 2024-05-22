using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.Customer;
using JewelryAuction.Business.DAO;
using JewelryAuction.Business.ViewModels.Customer;
using JewelryAuction.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryAuction.Business.Services
{

    public interface ICustomerService
    {
        Task<CustomerViewModel> CreateCustomer(CreateCustomerRequestModel customerCreate);
        Task<CustomerViewModel> UpdateCustomer(UpdateCustomerRequestModel customerUpdate);
        Task<bool> DeleteCustomer(int id);
        Task<List<CustomerViewModel>> GetAll();
        Task<CustomerViewModel> GetById(int id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly CustomerDAO _customerDAO;
        public CustomerService(IMapper mapper, CustomerDAO customerDAO)
        {
            _mapper = mapper;
            _customerDAO = customerDAO;
        }

        public async Task<CustomerViewModel> CreateCustomer(CreateCustomerRequestModel customerCreate)
        {
            var customer = _mapper.Map<Customer>(customerCreate);
            await _customerDAO.CreateAsync(customer);
            return _mapper.Map<CustomerViewModel>(customer);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await _customerDAO.GetByIdAsync(id);
            if (customer == null)
                throw new Exception($"Customer with ID {id} not found.");

            return await _customerDAO.RemoveAsync(customer);
        }

        public async Task<List<CustomerViewModel>> GetAll()
        {
            var customers = await _customerDAO.GetAllAsync();
            return _mapper.Map<List<CustomerViewModel>>(customers);
        }

        public async Task<CustomerViewModel> GetById(int id)
        {
            var customer = await _customerDAO.GetByIdAsync(id);
            if (customer == null)
                throw new Exception($"Customer with ID {id} not found.");

            return _mapper.Map<CustomerViewModel>(customer);
        }

        public async Task<CustomerViewModel> UpdateCustomer(UpdateCustomerRequestModel customerUpdate)
        {
            var customer = await _customerDAO.GetByIdAsync(customerUpdate.UserId);
            if (customer == null)
                throw new Exception($"Customer with ID {customerUpdate.UserId} not found.");

            _mapper.Map(customerUpdate, customer);
            await _customerDAO.UpdateAsync(customer);
            return _mapper.Map<CustomerViewModel>(customer);
        }
    }
}
