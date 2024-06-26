﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace JewelryAuction.Data.Models;

public partial class AuctionSession
{
    public int BidNumber { get; set; }

    public int? BidItemId { get; set; }

    public string BidComment { get; set; }

    public DateTime? BidDate { get; set; }

    public TimeOnly? BidTime { get; set; }

    public int? BidderId { get; set; }

    public int? AuctionId { get; set; }

    public virtual AuctionRequest Auction { get; set; }

    public virtual AuctionRequestDetail BidItem { get; set; }

    public virtual Customer Bidder { get; set; }
}