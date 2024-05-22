using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.AuctionResult;
using JewelryAuction.Business.DAO;
using JewelryAuction.Business.ViewModels.AuctionResult;
using JewelryAuction.Business.ViewModels.AuctionSession;
using JewelryAuction.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryAuction.Business.Services
{

    public interface IAuctionResultService
    {
        Task<AuctionResultViewModel> CreateAuctionResult(CreateAuctionResultRequestModel auctionresultCreate);
        Task<AuctionResultViewModel> UpdateAuctionResult(UpdateAuctionResultRequestModel auctionresultUpdate);
        Task<bool> DeleteAuctionResult(int id);
        Task<List<AuctionResultViewModel>> GetAll();
        Task<AuctionResultViewModel> GetById(int id);
    }

    public class AuctionResultService : IAuctionResultService
    {
        private readonly IMapper _mapper;
        private readonly AuctionResultDAO _auctionResultDAO;
        public AuctionResultService(IMapper mapper, AuctionResultDAO auctionResultDAO)
        {
            _mapper = mapper;
            _auctionResultDAO = auctionResultDAO;
        }

        public async Task<AuctionResultViewModel> CreateAuctionResult(CreateAuctionResultRequestModel auctionresultCreate)
        {
            var auctionResult = _mapper.Map<AuctionResult>(auctionresultCreate);
            await _auctionResultDAO.CreateAsync(auctionResult);
            return _mapper.Map<AuctionResultViewModel>(auctionResult);
        }

        public async Task<bool> DeleteAuctionResult(int id)
        {
            var auctionResult = await _auctionResultDAO.GetByIdAsync(id);
            if (auctionResult == null)
                throw new Exception($"AuctionResult with ID {id} not found.");

            return await _auctionResultDAO.RemoveAsync(auctionResult);
        }

        public async Task<List<AuctionResultViewModel>> GetAll()
        {
            var auctionResult = await _auctionResultDAO.GetAllAsync();
            return _mapper.Map<List<AuctionResultViewModel>>(auctionResult);
        }

        public async Task<AuctionResultViewModel> GetById(int id)
        {
            var auctionResult = await _auctionResultDAO.GetByIdAsync(id);
            if (auctionResult == null)
                throw new Exception($"AuctionResult with ID {id} not found.");

            return _mapper.Map<AuctionResultViewModel>(auctionResult);
        }

        public async Task<AuctionResultViewModel> UpdateAuctionResult(UpdateAuctionResultRequestModel auctionresultUpdate)
        {
            var auctionResult = await _auctionResultDAO.GetByIdAsync(auctionresultUpdate.AucId);
            if (auctionResult == null)
                throw new Exception($"AuctionResult with ID {auctionresultUpdate.AucId} not found.");

            _mapper.Map(auctionresultUpdate, auctionResult);
            await _auctionResultDAO.UpdateAsync(auctionResult);
            return _mapper.Map<AuctionResultViewModel>(auctionResult);
        }
    }
}
