using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.AuctionSession;
using JewelryAuction.Business.DAO;
using JewelryAuction.Business.ViewModels.AuctionSession;
using JewelryAuction.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryAuction.Business.Services
{

    public interface IAuctionSessionService
    {
        Task<AuctionSessionViewModel> CreateAuctionSession(CreateAuctionSessionRequestModel auctionsessionCreate);
        Task<AuctionSessionViewModel> UpdateAuctionSession(UpdateAuctionSessionRequestModel auctionsessionUpdate);
        Task<bool> DeleteAuctionSession(int id);
        Task<List<AuctionSessionViewModel>> GetAll();
        Task<AuctionSessionViewModel> GetById(int id);
    }

    public class AuctionSessionService : IAuctionSessionService
    {
        private readonly IMapper _mapper;
        private readonly AuctionSessionDAO _auctionSessionDAO;

        public AuctionSessionService(IMapper mapper, AuctionSessionDAO auctionSessionDAO)
        {
            _mapper = mapper;
            _auctionSessionDAO = auctionSessionDAO;
        }

        public async Task<AuctionSessionViewModel> CreateAuctionSession(CreateAuctionSessionRequestModel auctionsessionCreate)
        {
            var auctionSession = _mapper.Map<AuctionSession>(auctionsessionCreate);
            await _auctionSessionDAO.CreateAsync(auctionSession);
            return _mapper.Map<AuctionSessionViewModel>(auctionSession);
        }

        public async Task<bool> DeleteAuctionSession(int id)
        {
            var auctionSession = await _auctionSessionDAO.GetByIdAsync(id);
            if (auctionSession == null)
                throw new Exception($"AuctionSession with ID {id} not found.");

            return await _auctionSessionDAO.RemoveAsync(auctionSession);
        }

        public async Task<List<AuctionSessionViewModel>> GetAll()
        {
            var auctionSession = await _auctionSessionDAO.GetAllAsync();
            return _mapper.Map<List<AuctionSessionViewModel>>(auctionSession);
        }

        public async Task<AuctionSessionViewModel> GetById(int id)
        {
            var auctionSession = await _auctionSessionDAO.GetByIdAsync(id);
            if (auctionSession == null)
                throw new Exception($"AuctionSession with ID {id} not found.");

            return _mapper.Map<AuctionSessionViewModel>(auctionSession);
        }

        public async Task<AuctionSessionViewModel> UpdateAuctionSession(UpdateAuctionSessionRequestModel auctionsessionUpdate)
        {
            var auctionSession = await _auctionSessionDAO.GetByIdAsync(auctionsessionUpdate.Id);
            if (auctionSession == null)
                throw new Exception($"AuctionSession with ID {auctionsessionUpdate.Id} not found.");

            _mapper.Map(auctionsessionUpdate, auctionSession);
            await _auctionSessionDAO.UpdateAsync(auctionSession);
            return _mapper.Map<AuctionSessionViewModel>(auctionSession);
        }
    }
}
