using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.Customer;
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
        private readonly NET1710_221_1_JewelryAuctionContext _context;
        public CustomerService(IMapper mapper, NET1710_221_1_JewelryAuctionContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CustomerViewModel> CreateCustomer(CreateCustomerRequestModel customerCreate)
        {
            var customer = _mapper.Map<Customer>(customerCreate);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustomerViewModel>(customer);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                throw new Exception($"Customer with ID {id} not found.");

            _context.Customers.Remove(customer);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<CustomerViewModel>> GetAll()
        {
            var customers = await _context.Customers.ToListAsync();
            return _mapper.Map<List<CustomerViewModel>>(customers);
        }

        public async Task<CustomerViewModel> GetById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                throw new Exception($"Customer with ID {id} not found.");

            return _mapper.Map<CustomerViewModel>(customer);
        }

        public async Task<CustomerViewModel> UpdateCustomer(UpdateCustomerRequestModel customerUpdate)
        {
            var customer = await _context.Customers.FindAsync(customerUpdate.UserId);
            if (customer == null)
                throw new Exception($"Customer with ID {customerUpdate.UserId} not found.");

            _mapper.Map(customerUpdate, customer);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustomerViewModel>(customer);
        }
    }
}
