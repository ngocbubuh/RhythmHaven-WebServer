using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RhythmHaven.Repository.Entities;

public partial class RhythmHavenContext : DbContext
{
    public RhythmHavenContext()
    {
    }

    public RhythmHavenContext(DbContextOptions<RhythmHavenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC07E76F879E");

            entity.ToTable("Account");

            entity.Property(e => e.Id);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cart__3214EC076C3A46F3");

            entity.ToTable("Cart");

            entity.Property(e => e.Id);
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Account).WithMany(p => p.Carts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_Account");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_Product");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC073E746964");

            entity.ToTable("Order");

            entity.Property(e => e.Id);
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Account");

            entity.HasOne(d => d.Transaction).WithOne(p => p.Order)
                .HasForeignKey<Order>(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Transaction");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC07CDA60834");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Id);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Order");
            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07A00AA703");

            entity.ToTable("Product");

            entity.Property(e => e.Id);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC07F359CC31");

            entity.ToTable("Transaction");

            entity.Property(e => e.Id);
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Version)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Account).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaction_Account");
            entity.HasOne(d => d.Order).WithOne(o => o.Transaction)
                .HasForeignKey<Order>(o => o.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
