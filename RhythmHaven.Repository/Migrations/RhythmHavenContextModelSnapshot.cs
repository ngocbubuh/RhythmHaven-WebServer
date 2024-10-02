﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RhythmHaven.Repository.Entities;

#nullable disable

namespace RhythmHaven.Repository.Migrations
{
    [DbContext(typeof(RhythmHavenContext))]
    partial class RhythmHavenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RhythmHaven.Repository.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<double>("Credit")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnsignName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id")
                        .HasName("PK__Account__3214EC07E76F879E");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("RhythmHaven.Repository.Entities.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AccountID");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id")
                        .HasName("PK__Cart__3214EC076C3A46F3");

                    b.HasIndex("AccountId");

                    b.HasIndex("ProductId");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("RhythmHaven.Repository.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AccountID");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TransactionID");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id")
                        .HasName("PK__Order__3214EC073E746964");

                    b.HasIndex("AccountId");

                    b.HasIndex("TransactionId")
                        .IsUnique();

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("RhythmHaven.Repository.Entities.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OrderID");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id")
                        .HasName("PK__OrderDet__3214EC07CDA60834");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("RhythmHaven.Repository.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id")
                        .HasName("PK__Product__3214EC07A00AA703");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("RhythmHaven.Repository.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AccountID");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("TransactionDes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TransactionStatus")
                        .HasColumnType("bit");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id")
                        .HasName("PK__Transact__3214EC07F359CC31");

                    b.HasIndex("AccountId");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("RhythmHaven.Repository.Entities.Cart", b =>
                {
                    b.HasOne("RhythmHaven.Repository.Entities.Account", "Account")
                        .WithMany("Carts")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_Cart_Account");

                    b.HasOne("RhythmHaven.Repository.Entities.Product", "Product")
                        .WithMany("Carts")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Cart_Product");

                    b.Navigation("Account");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RhythmHaven.Repository.Entities.Order", b =>
                {
                    b.HasOne("RhythmHaven.Repository.Entities.Account", "Account")
                        .WithMany("Orders")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_Order_Account");

                    b.HasOne("RhythmHaven.Repository.Entities.Transaction", "Transaction")
                        .WithOne("Order")
                        .HasForeignKey("RhythmHaven.Repository.Entities.Order", "TransactionId")
                        .IsRequired()
                        .HasConstraintName("FK_Order_Transaction");

                    b.Navigation("Account");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("RhythmHaven.Repository.Entities.OrderDetail", b =>
                {
                    b.HasOne("RhythmHaven.Repository.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderDetail_Order");

                    b.HasOne("RhythmHaven.Repository.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RhythmHaven.Repository.Entities.Transaction", b =>
                {
                    b.HasOne("RhythmHaven.Repository.Entities.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_Transaction_Account");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("RhythmHaven.Repository.Entities.Account", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Orders");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("RhythmHaven.Repository.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("RhythmHaven.Repository.Entities.Product", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("RhythmHaven.Repository.Entities.Transaction", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
