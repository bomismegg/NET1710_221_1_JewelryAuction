using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.AuctionResult;
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
        private readonly NET1710_221_1_JewelryAuctionContext _context;
        public AuctionResultService(IMapper mapper, NET1710_221_1_JewelryAuctionContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<AuctionResultViewModel> CreateAuctionResult(CreateAuctionResultRequestModel auctionresultCreate)
        {
            var auctionResult = _mapper.Map<AuctionResult>(auctionresultCreate);
            _context.AuctionResults.Add(auctionResult);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuctionResultViewModel>(auctionResult);
        }

        public async Task<bool> DeleteAuctionResult(int id)
        {
            var auctionResult = await _context.AuctionResults.FindAsync(id);
            if (auctionResult == null)
                throw new Exception($"AuctionResult with ID {id} not found.");

            _context.AuctionResults.Remove(auctionResult);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<AuctionResultViewModel>> GetAll()
        {
            var auctionResult = await _context.AuctionResults.ToListAsync();
            return _mapper.Map<List<AuctionResultViewModel>>(auctionResult);
        }

        public async Task<AuctionResultViewModel> GetById(int id)
        {
            var auctionResult = await _context.AuctionResults.FindAsync(id);
            if (auctionResult == null)
                throw new Exception($"AuctionResult with ID {id} not found.");

            return _mapper.Map<AuctionResultViewModel>(auctionResult);
        }

        public async Task<AuctionResultViewModel> UpdateAuctionResult(UpdateAuctionResultRequestModel auctionresultUpdate)
        {
            var auctionResult = await _context.AuctionResults.FindAsync(auctionresultUpdate.AucId);
            if (auctionResult == null)
                throw new Exception($"AuctionResult with ID {auctionresultUpdate.AucId} not found.");

            _mapper.Map(auctionresultUpdate, auctionResult);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuctionResultViewModel>(auctionResult);
        }
    }
}
