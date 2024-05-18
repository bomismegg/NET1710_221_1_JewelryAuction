﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace JewelryAuction.Data.Models;

public partial class Customer
{
    public int UserId { get; set; }

    public string UserFname { get; set; }

    public string UserLname { get; set; }

    public string UserStreetNo { get; set; }

    public string UserStreetName { get; set; }

    public string UserCity { get; set; }

    public string UserCountry { get; set; }

    public string UserPhoneNo { get; set; }

    public int? UserAdminId { get; set; }

    public virtual ICollection<AuctionResult> AuctionResults { get; set; } = new List<AuctionResult>();

    public virtual ICollection<AuctionSession> AuctionSessions { get; set; } = new List<AuctionSession>();
}