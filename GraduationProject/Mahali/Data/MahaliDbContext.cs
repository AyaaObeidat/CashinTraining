﻿using Mahali.Models;
using Microsoft.EntityFrameworkCore;

namespace Mahali.Data
{
    public class MahaliDbContext : DbContext
    {
        protected MahaliDbContext() { }
        public MahaliDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<WishList> wishLists { get; set; }
        public DbSet<CartProducts> CartProducts { get; set; }
        public DbSet<WishListProducts> WishListProducts { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Decimal
            modelBuilder.Entity<Cart>()
           .Property(p => p.TotalAmount)
           .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<CartProducts>()
           .Property(p => p.UnitPrice)
           .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Product>()
           .Property(p => p.Price)
           .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Order>()
           .Property(p => p.TotalAmount)
           .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<OrderProducts>()
           .Property(p => p.UnitPrice)
           .HasColumnType("decimal(18, 2)");

            //Enum
            modelBuilder.Entity<CartProducts>()
           .Property(o => o.Size)
           .HasConversion<string>();

            modelBuilder.Entity<CartProducts>()
           .Property(o => o.Color)
           .HasConversion<string>();

            modelBuilder.Entity<ProductColors>()
           .Property(o => o.Color)
           .HasConversion<string>();

            modelBuilder.Entity<ProductSizes>()
           .Property(o => o.Size)
           .HasConversion<string>();

            modelBuilder.Entity<Order>()
           .Property(o => o.Type)
           .HasConversion<string>();

            modelBuilder.Entity<Order>()
           .Property(o => o.Status)
           .HasConversion<string>();

            modelBuilder.Entity<OrderProducts>()
          .Property(o => o.Size)
          .HasConversion<string>();

            modelBuilder.Entity<OrderProducts>()
          .Property(o => o.Color)
          .HasConversion<string>();

        }

    }
}