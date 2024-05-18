using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.PaymentMethod;
using JewelryAuction.Business.ViewModels.PaymentMethod;
using JewelryAuction.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryAuction.Business.Services
{

    public interface IPaymentMethodService
    {
        Task<PaymentMethodViewModel> CreatePaymentMethod(CreatePaymentMethodRequestModel paymentmethodCreate);
        Task<PaymentMethodViewModel> UpdatePaymentMethod(UpdatePaymentMethodRequestModel paymentmethodUpdate);
        Task<bool> DeletePaymentMethod(int id);
        Task<List<PaymentMethodViewModel>> GetAll();
        Task<PaymentMethodViewModel> GetById(int id);
    }

    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IMapper _mapper;
        private readonly NET1710_221_1_JewelryAuctionContext _context;

        public PaymentMethodService(IMapper mapper, NET1710_221_1_JewelryAuctionContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PaymentMethodViewModel> CreatePaymentMethod(CreatePaymentMethodRequestModel request)
        {
            var paymentMethod = _mapper.Map<PaymentMethod>(request);
            _context.PaymentMethods.Add(paymentMethod);
            await _context.SaveChangesAsync();
            return _mapper.Map<PaymentMethodViewModel>(paymentMethod);
        }

        public async Task<bool> DeletePaymentMethod(int id)
        {
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethod == null)
                throw new Exception($"PaymentMethod with ID {id} not found.");

            _context.PaymentMethods.Remove(paymentMethod);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<PaymentMethodViewModel>> GetAll()
        {
            var paymentMethods = await _context.PaymentMethods.ToListAsync();
            return _mapper.Map<List<PaymentMethodViewModel>>(paymentMethods);
        }

        public async Task<PaymentMethodViewModel> GetById(int id)
        {
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethod == null)
                throw new Exception($"PaymentMethod with ID {id} not found.");

            return _mapper.Map<PaymentMethodViewModel>(paymentMethod);
        }

        public async Task<PaymentMethodViewModel> UpdatePaymentMethod(UpdatePaymentMethodRequestModel paymentmethodUpdate)
        {
            var paymentMethod = await _context.PaymentMethods.FindAsync(paymentmethodUpdate.PaymentMethodId);
            if (paymentMethod == null)
                throw new Exception($"PaymentMethod with ID {paymentmethodUpdate.PaymentMethodId} not found.");

            _mapper.Map(paymentmethodUpdate, paymentMethod);
            await _context.SaveChangesAsync();
            return _mapper.Map<PaymentMethodViewModel>(paymentMethod);
        }
    }

}
