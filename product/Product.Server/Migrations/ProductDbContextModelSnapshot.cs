﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using product.Data;

#nullable disable

namespace Product.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("product")
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("product.Models.BoothEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("Booth", "product");
                });

            modelBuilder.Entity("product.Models.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<Guid>("BoothId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.HasIndex("BoothId");

                    b.ToTable("Product", "product");
                });

            modelBuilder.Entity("product.Models.RateEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("CommentBody")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CommentBody");

                    b.Property<string>("CommentTitle")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("CommentTitle");

                    b.Property<int>("Grade")
                        .HasColumnType("integer")
                        .HasColumnName("Grade");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Rate", "product");
                });

            modelBuilder.Entity("product.Models.StockEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Category");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Department");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Gender");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("Price");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("Quantity");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Size");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Stock", "product");
                });

            modelBuilder.Entity("product.Models.ProductEntity", b =>
                {
                    b.HasOne("product.Models.BoothEntity", "Booth")
                        .WithMany("Products")
                        .HasForeignKey("BoothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booth");
                });

            modelBuilder.Entity("product.Models.RateEntity", b =>
                {
                    b.HasOne("product.Models.ProductEntity", "Product")
                        .WithMany("Rates")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("product.Models.StockEntity", b =>
                {
                    b.HasOne("product.Models.ProductEntity", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("product.Models.BoothEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("product.Models.ProductEntity", b =>
                {
                    b.Navigation("Rates");

                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
