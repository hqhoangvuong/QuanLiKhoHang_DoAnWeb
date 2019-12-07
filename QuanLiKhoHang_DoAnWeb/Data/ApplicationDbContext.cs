﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLiKhoHang_DoAnWeb.Models;

namespace QuanLiKhoHang_DoAnWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Products>()
                .Property(a => a.Stock)
                .HasDefaultValueSql("0");
            modelBuilder.Entity<SaleOrders>()
                .Property(a => a.isConfirmed)
                .HasDefaultValue(false);
        }

        public DbSet<ProductTypes> productTypes { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Clients> clients { get; set; }
        public DbSet<Vendors> vendors { get; set; }
        public DbSet<SaleOrders> saleOrders { get; set; }
        public DbSet<SaleOrderDetails> saleOrderDetails { get; set; }
        public DbSet<PurchaseOrders> purchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetails> purchaseOrderDetails { get; set; }
        public DbSet<ApplicationUsers> applicationUsers { get; set; }
    }
}
