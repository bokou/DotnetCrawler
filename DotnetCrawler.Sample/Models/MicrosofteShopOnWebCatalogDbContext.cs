﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotnetCrawler.Sample.Models
{
    public partial class MicrosofteShopOnWebCatalogDbContext : DbContext
    {
        public MicrosofteShopOnWebCatalogDbContext()
        {
        }

        public MicrosofteShopOnWebCatalogDbContext(DbContextOptions<MicrosofteShopOnWebCatalogDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BasketItems> BasketItems { get; set; }
        public virtual DbSet<Baskets> Baskets { get; set; }
        public virtual DbSet<Catalog> Catalog { get; set; }
        public virtual DbSet<CatalogBrands> CatalogBrands { get; set; }
        public virtual DbSet<CatalogTypes> CatalogTypes { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Microsoft.eShopOnWeb.CatalogDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<BasketItems>(entity =>
            {
                entity.HasIndex(e => e.BasketId);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Basket)
                    .WithMany(p => p.BasketItems)
                    .HasForeignKey(d => d.BasketId);
            });

            modelBuilder.Entity<Baskets>(entity =>
            {
                entity.Property(e => e.BuyerId)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.HasIndex(e => e.CatalogBrandId);

                entity.HasIndex(e => e.CatalogTypeId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CatalogBrand)
                    .WithMany(p => p.Catalog)
                    .HasForeignKey(d => d.CatalogBrandId);

                entity.HasOne(d => d.CatalogType)
                    .WithMany(p => p.Catalog)
                    .HasForeignKey(d => d.CatalogTypeId);
            });

            modelBuilder.Entity<CatalogBrands>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CatalogTypes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasIndex(e => e.OrderId);

                entity.Property(e => e.ItemOrderedCatalogItemId).HasColumnName("ItemOrdered_CatalogItemId");

                entity.Property(e => e.ItemOrderedPictureUri).HasColumnName("ItemOrdered_PictureUri");

                entity.Property(e => e.ItemOrderedProductName)
                    .HasColumnName("ItemOrdered_ProductName")
                    .HasMaxLength(50);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.ShipToAddressCity)
                    .HasColumnName("ShipToAddress_City")
                    .HasMaxLength(100);

                entity.Property(e => e.ShipToAddressCountry)
                    .HasColumnName("ShipToAddress_Country")
                    .HasMaxLength(90);

                entity.Property(e => e.ShipToAddressState)
                    .HasColumnName("ShipToAddress_State")
                    .HasMaxLength(60);

                entity.Property(e => e.ShipToAddressStreet)
                    .HasColumnName("ShipToAddress_Street")
                    .HasMaxLength(180);

                entity.Property(e => e.ShipToAddressZipCode)
                    .HasColumnName("ShipToAddress_ZipCode")
                    .HasMaxLength(18);
            });

            modelBuilder.HasSequence("catalog_brand_hilo").IncrementsBy(10);

            modelBuilder.HasSequence("catalog_hilo").IncrementsBy(10);

            modelBuilder.HasSequence("catalog_type_hilo").IncrementsBy(10);
        }
    }
}
