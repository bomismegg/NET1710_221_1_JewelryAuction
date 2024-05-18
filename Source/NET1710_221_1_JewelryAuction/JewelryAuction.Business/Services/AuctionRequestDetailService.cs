using AutoMapper;
using Ecommerce.BusinessLogic.RequestModels.AuctionRequestDetail;
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
        private readonly NET1710_221_1_JewelryAuctionContext _context;
        public AuctionRequestDetailService(IMapper mapper, NET1710_221_1_JewelryAuctionContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<AuctionRequestDetailViewModel> CreateAuctionRequestDetail(CreateAuctionRequestDetailRequestModel auctionrequestdetailCreate)
        {
            var auctionRequestDetail = _mapper.Map<AuctionRequestDetail>(auctionrequestdetailCreate);
            _context.AuctionRequestDetails.Add(auctionRequestDetail);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuctionRequestDetailViewModel>(auctionRequestDetail);
        }

        public async Task<bool> DeleteAuctionRequestDetail(int id)
        {
            var auctionRequestDetail = await _context.AuctionRequestDetails.FindAsync(id);
            if (auctionRequestDetail == null)
                throw new Exception($"AuctionRequestDetail with ID {id} not found.");

            _context.AuctionRequestDetails.Remove(auctionRequestDetail);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<AuctionRequestDetailViewModel>> GetAll()
        {
            var auctionRequestDetails = await _context.AuctionRequestDetails.ToListAsync();
            return _mapper.Map<List<AuctionRequestDetailViewModel>>(auctionRequestDetails);
        }

        public async Task<AuctionRequestDetailViewModel> GetById(int id)
        {
            var auctionRequestDetails = await _context.AuctionRequests.FindAsync(id);
            if (auctionRequestDetails == null)
                throw new Exception($"AuctionRequestDetail with ID {id} not found.");

            return _mapper.Map<AuctionRequestDetailViewModel>(auctionRequestDetails);
        }

        public async Task<AuctionRequestDetailViewModel> UpdateAuctionRequestDetail(UpdateAuctionRequestDetailRequestModel auctionrequestdetailUpdate)
        {
            var auctionRequestDetail = await _context.AuctionRequestDetails.FindAsync(auctionrequestdetailUpdate.ProductId);
            if (auctionRequestDetail == null)
                throw new Exception($"AuctionRequestDetail with ID {auctionrequestdetailUpdate.ProductId} not found.");

            _mapper.Map(auctionrequestdetailUpdate, auctionRequestDetail);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuctionRequestDetailViewModel>(auctionRequestDetail);
        }
    }
}
