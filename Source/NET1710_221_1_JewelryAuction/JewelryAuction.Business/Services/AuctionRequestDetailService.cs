using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.AuctionRequestDetail;
using JewelryAuction.Business.DAO;
using JewelryAuction.Business.ViewModels.AuctionRequest;
using JewelryAuction.Business.ViewModels.AuctionRequestDetail;
using JewelryAuction.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryAuction.Business.Services
{

    public interface IAuctionRequestDetailService
    {
        Task<AuctionRequestDetailViewModel> CreateAuctionRequestDetail(CreateAuctionRequestDetailRequestModel auctionrequestdetailCreate);
        Task<AuctionRequestDetailViewModel> UpdateAuctionRequestDetail(UpdateAuctionRequestDetailRequestModel auctionrequestdetailUpdate);
        Task<bool> DeleteAuctionRequestDetail(int id);
        Task<List<AuctionRequestDetailViewModel>> GetAll();
        Task<AuctionRequestDetailViewModel> GetById(int id);
    }

    public class AuctionRequestDetailService : IAuctionRequestDetailService
    {
        private readonly IMapper _mapper;
        private readonly AuctionRequestDetailDAO _auctionRequestDetailDAO;
        public AuctionRequestDetailService(IMapper mapper, AuctionRequestDetailDAO auctionRequestDetailDAO)
        {
            _mapper = mapper;
            _auctionRequestDetailDAO = auctionRequestDetailDAO;
        }

        public async Task<AuctionRequestDetailViewModel> CreateAuctionRequestDetail(CreateAuctionRequestDetailRequestModel auctionrequestdetailCreate)
        {
            var auctionRequestDetail = _mapper.Map<AuctionRequestDetail>(auctionrequestdetailCreate);
            await _auctionRequestDetailDAO.CreateAsync(auctionRequestDetail);
            return _mapper.Map<AuctionRequestDetailViewModel>(auctionRequestDetail);
        }

        public async Task<bool> DeleteAuctionRequestDetail(int id)
        {
            var auctionRequestDetail = await _auctionRequestDetailDAO.GetByIdAsync(id);
            if (auctionRequestDetail == null)
                throw new Exception($"AuctionRequestDetail with ID {id} not found.");
            return await _auctionRequestDetailDAO.RemoveAsync(auctionRequestDetail);
        }

        public async Task<List<AuctionRequestDetailViewModel>> GetAll()
        {
            var auctionRequestDetails = await _auctionRequestDetailDAO.GetAllAsync();
            return _mapper.Map<List<AuctionRequestDetailViewModel>>(auctionRequestDetails);
        }

        public async Task<AuctionRequestDetailViewModel> GetById(int id)
        {
            var auctionRequestDetails = await _auctionRequestDetailDAO.GetByIdAsync(id);
            if (auctionRequestDetails == null)
                throw new Exception($"AuctionRequestDetail with ID {id} not found.");

            return _mapper.Map<AuctionRequestDetailViewModel>(auctionRequestDetails);
        }

        public async Task<AuctionRequestDetailViewModel> UpdateAuctionRequestDetail(UpdateAuctionRequestDetailRequestModel auctionrequestdetailUpdate)
        {
            var auctionRequestDetail = await _auctionRequestDetailDAO.GetByIdAsync(auctionrequestdetailUpdate.ProductId);
            if (auctionRequestDetail == null)
                throw new Exception($"AuctionRequestDetail with ID {auctionrequestdetailUpdate.ProductId} not found.");

            _mapper.Map(auctionrequestdetailUpdate, auctionRequestDetail);
            await _auctionRequestDetailDAO.UpdateAsync(auctionRequestDetail);
            return _mapper.Map<AuctionRequestDetailViewModel>(auctionRequestDetail);
        }
    }
}
