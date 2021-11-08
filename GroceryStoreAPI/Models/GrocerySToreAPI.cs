using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GroceryStoreAPI.Models
{
    public partial class GrocerySToreAPI : DbContext
    {
        public GrocerySToreAPI()
        {
        }

        public GrocerySToreAPI(DbContextOptions<GrocerySToreAPI> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=CHANGEISBAD\\SQLEXPRESS;initial catalog=HomeApps;integrated security=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Items", "Grocery");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.ToTable("Lists", "Grocery");

                entity.Property(e => e.ListId).HasColumnName("ListID");

                entity.Property(e => e.FoodItemId).HasColumnName("FoodItemID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FoodItem)
                    .WithMany(p => p.Lists)
                    .HasForeignKey(d => d.FoodItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lists_Items");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Lists)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lists_Strores");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("Prices", "Grocery");

                entity.Property(e => e.PriceId)
                    .ValueGeneratedNever()
                    .HasColumnName("PriceID");

                entity.Property(e => e.FoodItemId).HasColumnName("FoodItemID");

                entity.Property(e => e.Price1)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Price");

                entity.Property(e => e.PriceDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.FoodItem)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.FoodItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prices_Items");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prices_Strores");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Stores", "Grocery");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
