﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GOMS.Web.Core.Models;

public partial class GORMContext : DbContext
{
    public GORMContext()
    {
    }

    public GORMContext(DbContextOptions<GORMContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdvertiseSource> AdvertiseSources { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ExpensesAndSale> ExpensesAndSales { get; set; }

    public virtual DbSet<Grocery> Groceries { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderType> OrderTypes { get; set; }

    public virtual DbSet<OrderTypePrice> OrderTypePrices { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Stater> Staters { get; set; }

    public virtual DbSet<StaterPrice> StaterPrices { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WeekDatum> WeekData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GaddamDumBiriyaniDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdvertiseSource>(entity =>
        {
            entity.HasKey(e => e.AdvertiseId);

            entity.ToTable("AdvertiseSource");

            entity.Property(e => e.AdvertiseDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ReferredBy)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpensesId);

            entity.ToTable("Expense");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ExpensesDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ExpensesAndSale>(entity =>
        {
            entity.HasKey(e => e.Esid);

            entity.Property(e => e.Esid).HasColumnName("ESId");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.TotalExpenses).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalSales).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Grocery>(entity =>
        {
            entity.ToTable("Grocery");

            entity.Property(e => e.GroceryDescription).HasMaxLength(250);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.LocationDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AmountPaidDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderType>(entity =>
        {
            entity.ToTable("OrderType");

            entity.Property(e => e.OrderTypeName).HasMaxLength(300);
        });

        modelBuilder.Entity<OrderTypePrice>(entity =>
        {
            entity.ToTable("OrderTypePrice");

            entity.Property(e => e.OrderTypePrice1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("OrderTypePrice");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.ToTable("PaymentType");

            entity.Property(e => e.PaymentTypeDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stater>(entity =>
        {
            entity.HasKey(e => e.StaterId).HasName("PK_Starter");

            entity.ToTable("Stater");

            entity.Property(e => e.StaterDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StaterPrice>(entity =>
        {
            entity.HasKey(e => e.StaterItemId);

            entity.ToTable("StaterPrice");

            entity.Property(e => e.StaterPrice1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("StaterPrice");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.ToTable("Store");

            entity.Property(e => e.StoreName).HasMaxLength(250);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EmailId).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.LastName).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Salt).HasMaxLength(255);
        });

        modelBuilder.Entity<WeekDatum>(entity =>
        {
            entity.HasKey(e => e.WeekId);

            entity.Property(e => e.WeekDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
