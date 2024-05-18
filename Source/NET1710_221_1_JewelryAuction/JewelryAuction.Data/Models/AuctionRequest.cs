﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace JewelryAuction.Data.Models;

public partial class AuctionRequest
{
    public int AucId { get; set; }

    public DateTime? AucStartDate { get; set; }

    public DateTime? AucCloseDate { get; set; }

    public decimal? AucReservePrice { get; set; }

    public DateTime? AucPaymentDate { get; set; }

    public string AucWinnerFname { get; set; }

    public string AucWinnerLname { get; set; }

    public decimal? AucPaymentAmount { get; set; }

    public int? AucItemId { get; set; }

    public int? PaymentMethodId { get; set; }

    public virtual AuctionRequestDetail AucItem { get; set; }

    public virtual ICollection<AuctionResult> AuctionResults { get; set; } = new List<AuctionResult>();

    public virtual ICollection<AuctionSession> AuctionSessions { get; set; } = new List<AuctionSession>();

    public virtual PaymentMethod PaymentMethod { get; set; }
}