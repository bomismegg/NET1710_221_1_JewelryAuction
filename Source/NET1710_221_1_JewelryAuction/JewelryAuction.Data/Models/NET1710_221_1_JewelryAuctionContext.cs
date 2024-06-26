﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JewelryAuction.Data.Models;

public partial class NET1710_221_1_JewelryAuctionContext : DbContext
{
    public NET1710_221_1_JewelryAuctionContext()
    {
        
    }
    public NET1710_221_1_JewelryAuctionContext(DbContextOptions<NET1710_221_1_JewelryAuctionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuctionRequest> AuctionRequests { get; set; }

    public virtual DbSet<AuctionRequestDetail> AuctionRequestDetails { get; set; }

    public virtual DbSet<AuctionResult> AuctionResults { get; set; }

    public virtual DbSet<AuctionSession> AuctionSessions { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuctionRequest>(entity =>
        {
            entity.HasKey(e => e.AucId).HasName("PK__AuctionR__C224A29830BCA9C3");

            entity.ToTable("AuctionRequest");

            entity.Property(e => e.AucId)
                .ValueGeneratedNever()
                .HasColumnName("Auc_ID");
            entity.Property(e => e.AucCloseDate)
                .HasColumnType("datetime")
                .HasColumnName("Auc_Close_Date");
            entity.Property(e => e.AucItemId).HasColumnName("Auc_Item_ID");
            entity.Property(e => e.AucPaymentAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Auc_Payment_Amount");
            entity.Property(e => e.AucPaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("Auc_Payment_Date");
            entity.Property(e => e.AucReservePrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Auc_Reserve_Price");
            entity.Property(e => e.AucStartDate)
                .HasColumnType("datetime")
                .HasColumnName("Auc_Start_Date");
            entity.Property(e => e.AucWinnerFname)
                .HasMaxLength(255)
                .HasColumnName("Auc_Winner_FName");
            entity.Property(e => e.AucWinnerLname)
                .HasMaxLength(255)
                .HasColumnName("Auc_Winner_LName");
            entity.Property(e => e.PaymentMethodId).HasColumnName("Payment_Method_ID");

            entity.HasOne(d => d.AucItem).WithMany(p => p.AuctionRequests)
                .HasForeignKey(d => d.AucItemId)
                .HasConstraintName("FK__AuctionRe__Auc_I__412EB0B6");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.AuctionRequests)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK__AuctionRe__Payme__4222D4EF");
        });

        modelBuilder.Entity<AuctionRequestDetail>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__AuctionR__9834FB9ABD4D6FC3");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("Product_ID");
            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.MinBidIncrement)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Min_Bid_Increment");
            entity.Property(e => e.ProductDescription).HasColumnName("Product_Description");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("Product_Name");
            entity.Property(e => e.ProductStartBidAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Product_Start_Bid_Amount");
            entity.Property(e => e.SellerId).HasColumnName("Seller_ID");
        });

        modelBuilder.Entity<AuctionResult>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.AucId }).HasName("PK__AuctionR__BC4FDBB9CB9E62F2");

            entity.ToTable("AuctionResult");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.AucId).HasColumnName("Auc_ID");

            entity.HasOne(d => d.Auc).WithMany(p => p.AuctionResults)
                .HasForeignKey(d => d.AucId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AuctionRe__Auc_I__4316F928");

            entity.HasOne(d => d.User).WithMany(p => p.AuctionResults)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AuctionRe__User___440B1D61");
        });

        modelBuilder.Entity<AuctionSession>(entity =>
        {
            entity.HasKey(e => e.BidNumber).HasName("PK__AuctionS__FBCB0D1DD25FB1CC");

            entity.ToTable("AuctionSession");

            entity.Property(e => e.BidNumber)
                .ValueGeneratedNever()
                .HasColumnName("Bid_Number");
            entity.Property(e => e.AuctionId).HasColumnName("Auction_ID");
            entity.Property(e => e.BidComment).HasColumnName("Bid_Comment");
            entity.Property(e => e.BidDate)
                .HasColumnType("datetime")
                .HasColumnName("Bid_Date");
            entity.Property(e => e.BidItemId).HasColumnName("Bid_Item_ID");
            entity.Property(e => e.BidTime).HasColumnName("Bid_Time");
            entity.Property(e => e.BidderId).HasColumnName("Bidder_ID");

            entity.HasOne(d => d.Auction).WithMany(p => p.AuctionSessions)
                .HasForeignKey(d => d.AuctionId)
                .HasConstraintName("FK__AuctionSe__Aucti__44FF419A");

            entity.HasOne(d => d.BidItem).WithMany(p => p.AuctionSessions)
                .HasForeignKey(d => d.BidItemId)
                .HasConstraintName("FK__AuctionSe__Bid_I__45F365D3");

            entity.HasOne(d => d.Bidder).WithMany(p => p.AuctionSessions)
                .HasForeignKey(d => d.BidderId)
                .HasConstraintName("FK__AuctionSe__Bidde__46E78A0C");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Customer__206D9190439F824C");

            entity.ToTable("Customer");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("User_ID");
            entity.Property(e => e.UserAdminId).HasColumnName("User_AdminID");
            entity.Property(e => e.UserCity)
                .HasMaxLength(255)
                .HasColumnName("User_City");
            entity.Property(e => e.UserCountry)
                .HasMaxLength(255)
                .HasColumnName("User_Country");
            entity.Property(e => e.UserFname)
                .HasMaxLength(255)
                .HasColumnName("User_FName");
            entity.Property(e => e.UserLname)
                .HasMaxLength(255)
                .HasColumnName("User_LName");
            entity.Property(e => e.UserPhoneNo)
                .HasMaxLength(255)
                .HasColumnName("User_PhoneNo");
            entity.Property(e => e.UserStreetName)
                .HasMaxLength(255)
                .HasColumnName("User_StreetName");
            entity.Property(e => e.UserStreetNo)
                .HasMaxLength(255)
                .HasColumnName("User_StreetNo");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PK__Payment___781302868C238932");

            entity.ToTable("Payment_Method");

            entity.Property(e => e.PaymentMethodId)
                .ValueGeneratedNever()
                .HasColumnName("Payment_Method_ID");
            entity.Property(e => e.PaymentMethodDescription)
                .HasMaxLength(255)
                .HasColumnName("Payment_Method_Description");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}