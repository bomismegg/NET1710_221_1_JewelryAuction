using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.AuctionRequest;
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
        private readonly NET1710_221_1_JewelryAuctionContext _context;
        public AuctionRequestService(IMapper mapper, NET1710_221_1_JewelryAuctionContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<AuctionRequestViewModel> CreateAuctionRequest(CreateAuctionRequestRequestModel auctionrequestCreate)
        {
            var auctionRequest = _mapper.Map<AuctionRequest>(auctionrequestCreate);
            _context.AuctionRequests.Add(auctionRequest);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuctionRequestViewModel>(auctionRequest);
        }

        public async Task<bool> DeleteAuctionRequest(int id)
        {
            var auctionRequest = await _context.AuctionRequests.FindAsync(id);
            if (auctionRequest == null)
                throw new Exception($"AuctionRequest with ID {id} not found.");

            _context.AuctionRequests.Remove(auctionRequest);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<AuctionRequestViewModel>> GetAll()
        {
            var auctionRequest = await _context.AuctionRequests.ToListAsync();
            return _mapper.Map<List<AuctionRequestViewModel>>(auctionRequest);
        }

        public async Task<AuctionRequestViewModel> GetById(int id)
        {
            var auctionRequest = await _context.AuctionRequests.FindAsync(id);
            if (auctionRequest == null)
                throw new Exception($"AuctionRequest with ID {id} not found.");

            return _mapper.Map<AuctionRequestViewModel>(auctionRequest);
        }

        public async Task<AuctionRequestViewModel> UpdateAuctionRequest(UpdateAuctionRequestRequestModel auctionrequestUpdate)
        {
            var auctionRequest = await _context.AuctionRequests.FindAsync(auctionrequestUpdate.AucId);
            if (auctionRequest == null)
                throw new Exception($"AuctionRequest with ID {auctionrequestUpdate.AucId} not found.");

            _mapper.Map(auctionrequestUpdate, auctionRequest);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuctionRequestViewModel>(auctionRequest);
        }
    }
}
