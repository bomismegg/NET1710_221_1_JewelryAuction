using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.AuctionSession;
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
        private readonly NET1710_221_1_JewelryAuctionContext _context;

        public AuctionSessionService(IMapper mapper, NET1710_221_1_JewelryAuctionContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<AuctionSessionViewModel> CreateAuctionSession(CreateAuctionSessionRequestModel auctionsessionCreate)
        {
            var auctionSession = _mapper.Map<AuctionSession>(auctionsessionCreate);
            _context.AuctionSessions.Add(auctionSession);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuctionSessionViewModel>(auctionSession);
        }

        public async Task<bool> DeleteAuctionSession(int id)
        {
            var auctionSession = await _context.AuctionSessions.FindAsync(id);
            if (auctionSession == null)
                throw new Exception($"AuctionSession with ID {id} not found.");

            _context.AuctionSessions.Remove(auctionSession);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<AuctionSessionViewModel>> GetAll()
        {
            var auctionSession = await _context.AuctionSessions.ToListAsync();
            return _mapper.Map<List<AuctionSessionViewModel>>(auctionSession);
        }

        public async Task<AuctionSessionViewModel> GetById(int id)
        {
            var auctionSession = await _context.AuctionSessions.FindAsync(id);
            if (auctionSession == null)
                throw new Exception($"AuctionSession with ID {id} not found.");

            return _mapper.Map<AuctionSessionViewModel>(auctionSession);
        }

        public async Task<AuctionSessionViewModel> UpdateAuctionSession(UpdateAuctionSessionRequestModel auctionsessionUpdate)
        {
            var auctionSession = await _context.AuctionSessions.FindAsync(auctionsessionUpdate.Id);
            if (auctionSession == null)
                throw new Exception($"AuctionSession with ID {auctionsessionUpdate.Id} not found.");

            _mapper.Map(auctionsessionUpdate, auctionSession);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuctionSessionViewModel>(auctionSession);
        }
    }
}
