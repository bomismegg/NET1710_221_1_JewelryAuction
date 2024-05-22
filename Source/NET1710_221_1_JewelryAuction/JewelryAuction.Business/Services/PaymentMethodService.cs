using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.PaymentMethod;
using JewelryAuction.Business.DAO;
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
        private readonly PaymentMethodDAO _paymentMethodDAO;

        public PaymentMethodService(IMapper mapper, PaymentMethodDAO paymentMethodDAO)
        {
            _mapper = mapper;
            _paymentMethodDAO = paymentMethodDAO;
        }

        public async Task<PaymentMethodViewModel> CreatePaymentMethod(CreatePaymentMethodRequestModel request)
        {
            var paymentMethod = _mapper.Map<PaymentMethod>(request);
            await _paymentMethodDAO.CreateAsync(paymentMethod);
            return _mapper.Map<PaymentMethodViewModel>(paymentMethod);
        }

        public async Task<bool> DeletePaymentMethod(int id)
        {
            var paymentMethod = await _paymentMethodDAO.GetByIdAsync(id);
            if (paymentMethod == null)
                throw new Exception($"PaymentMethod with ID {id} not found.");

            return await _paymentMethodDAO.RemoveAsync(paymentMethod);
        }

        public async Task<List<PaymentMethodViewModel>> GetAll()
        {
            var paymentMethods = await _paymentMethodDAO.GetAllAsync();
            return _mapper.Map<List<PaymentMethodViewModel>>(paymentMethods);
        }

        public async Task<PaymentMethodViewModel> GetById(int id)
        {
            var paymentMethod = await _paymentMethodDAO.GetByIdAsync(id);
            if (paymentMethod == null)
                throw new Exception($"PaymentMethod with ID {id} not found.");

            return _mapper.Map<PaymentMethodViewModel>(paymentMethod);
        }

        public async Task<PaymentMethodViewModel> UpdatePaymentMethod(UpdatePaymentMethodRequestModel paymentmethodUpdate)
        {
            var paymentMethod = await _paymentMethodDAO.GetByIdAsync(paymentmethodUpdate.PaymentMethodId);
            if (paymentMethod == null)
                throw new Exception($"PaymentMethod with ID {paymentmethodUpdate.PaymentMethodId} not found.");

            _mapper.Map(paymentmethodUpdate, paymentMethod);
            await _paymentMethodDAO.UpdateAsync(paymentMethod);
            return _mapper.Map<PaymentMethodViewModel>(paymentMethod);
        }
    }

}
