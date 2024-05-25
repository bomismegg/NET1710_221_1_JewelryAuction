using System;
using JewelryAuction.Data.Models;
using JewelryAuction.Data.Repository;

namespace JewelryAuction.Data
{
	public class UnitOfWork
	{
		private NET1710_221_1_JewelryAuctionContext _unitOfContext { get; set; }
		private AuctionRequestRepository _auctionRequest;

		public UnitOfWork()
		{

		}

		public AuctionRequestRepository AuctionRequestRepository
        {
			get
			{
				return _auctionRequest ??= new Repository.AuctionRequestRepository();

			}
				}
	}
}

