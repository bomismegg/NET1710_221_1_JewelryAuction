using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.AuctionRequest;
using JewelryAuction.Business.DAO;
using JewelryAuction.Business.ViewModels.AuctionRequest;
using JewelryAuction.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryAuction.Business.Services
{

    public interface IAuctionRequestService
    {
        Task<AuctionRequestViewModel> CreateAuctionRequest(CreateAuctionRequestRequestModel auctionrequestCreate);
        Task<AuctionRequestViewModel> UpdateAuctionRequest(UpdateAuctionRequestRequestModel auctionrequestUpdate);
        Task<bool> DeleteAuctionRequest(int id);
        Task<List<AuctionRequestViewModel>> GetAll();
        Task<AuctionRequestViewModel> GetById(int id);
    }

    public class AuctionRequestService : IAuctionRequestService
    {
        private readonly IMapper _mapper;
        private readonly AuctionRequestDAO _auctionRequestDAO;
        public AuctionRequestService(IMapper mapper, AuctionRequestDAO auctionRequestDAO)
        {
            _mapper = mapper;
            _auctionRequestDAO = auctionRequestDAO;
        }

        public async Task<AuctionRequestViewModel> CreateAuctionRequest(CreateAuctionRequestRequestModel auctionrequestCreate)
        {
            var auctionRequest = _mapper.Map<AuctionRequest>(auctionrequestCreate);
            await _auctionRequestDAO.CreateAsync(auctionRequest);
            return _mapper.Map<AuctionRequestViewModel>(auctionRequest);
        }

        public async Task<bool> DeleteAuctionRequest(int id)
        {
            var auctionRequest = await _auctionRequestDAO.GetByIdAsync(id);
            if (auctionRequest == null)
                throw new Exception($"AuctionRequest with ID {id} not found.");

            return await _auctionRequestDAO.RemoveAsync(auctionRequest);
        }

        public async Task<List<AuctionRequestViewModel>> GetAll()
        {
            var auctionRequest = await _auctionRequestDAO.GetAllAsync();
            return _mapper.Map<List<AuctionRequestViewModel>>(auctionRequest);
        }

        public async Task<AuctionRequestViewModel> GetById(int id)
        {
            var auctionRequest = await _auctionRequestDAO.GetByIdAsync(id);
            if (auctionRequest == null)
                throw new Exception($"AuctionRequest with ID {id} not found.");

            return _mapper.Map<AuctionRequestViewModel>(auctionRequest);
        }

        public async Task<AuctionRequestViewModel> UpdateAuctionRequest(UpdateAuctionRequestRequestModel auctionrequestUpdate)
        {
            var auctionRequest = await _auctionRequestDAO.GetByIdAsync(auctionrequestUpdate.AucId);
            if (auctionRequest == null)
                throw new Exception($"AuctionRequest with ID {auctionrequestUpdate.AucId} not found.");

            _mapper.Map(auctionrequestUpdate, auctionRequest);
            await _auctionRequestDAO.UpdateAsync(auctionRequest);
            return _mapper.Map<AuctionRequestViewModel>(auctionRequest);
        }
    }
}
