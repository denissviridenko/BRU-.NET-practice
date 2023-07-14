using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BuildShopPresentationLayer
{
    public partial class BuildShopContext : DbContext
    {
        public BuildShopContext()
        {
        }

        public BuildShopContext(DbContextOptions<BuildShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Delivery> Deliveries { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemsCategory> ItemsCategories { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderedItem> OrderedItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=BuildShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Delivery");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.OrderedId).HasColumnName("orderedId");

                entity.HasOne(d => d.Ordered)
                    .WithMany()
                    .HasForeignKey(d => d.OrderedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Delivery_Orders");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Brand)
                    .HasMaxLength(20)
                    .HasColumnName("brand")
                    .IsFixedLength();

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name")
                    .IsFixedLength();

                entity.Property(e => e.OriginCountry)
                    .HasMaxLength(20)
                    .HasColumnName("originCountry")
                    .IsFixedLength();

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_ItemsCategories");
            });

            modelBuilder.Entity<ItemsCategory>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ClientMobilePhone)
                    .HasMaxLength(13)
                    .HasColumnName("clientMobilePhone")
                    .IsFixedLength();

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(10)
                    .HasColumnName("paymentMethod")
                    .IsFixedLength();
            });

            modelBuilder.Entity<OrderedItem>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Item).HasColumnName("item");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderedItems_Orders");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
