using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBContext.Library
{
    public partial class Project0Context : DbContext
    {
        public Project0Context()
        {
        }

        public Project0Context(DbContextOptions<Project0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<OrderGames> OrderGames { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64D86FDAF275");

                entity.ToTable("Customers", "Project0");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.DefaultStore)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.DefaultStoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STORE_ID_Customers");
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.GameId)
                    .HasName("PK__Games__2AB897FDAD5735AE");

                entity.ToTable("Games", "Project0");

                entity.HasIndex(e => e.GameName)
                    .HasName("UQ__Games__B8372C599D158F31")
                    .IsUnique();

                entity.Property(e => e.AdvancedPrice).HasColumnType("money");

                entity.Property(e => e.GameName).HasMaxLength(100);

                entity.Property(e => e.StandardPrice).HasColumnType("money");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.GameId })
                    .HasName("CK_STORE_AND_GAME_ID");

                entity.ToTable("Inventory", "Project0");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GAME_ID_INVENTORY");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STORE_ID_INVENTORY");
            });

            modelBuilder.Entity<OrderGames>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.GameId })
                    .HasName("CK_ORDER_AND_GAME_ID");

                entity.ToTable("OrderGames", "Project0");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.OrderGames)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GAME_ID_OrderGames");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderGames)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_ID_OrderGames");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BCFCB7740ED");

                entity.ToTable("Orders", "Project0");

                entity.Property(e => e.OrderCost).HasColumnType("money");

                entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.OrderCustomer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOMER_ID_ORDERS");

                entity.HasOne(d => d.OrderStore)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STORE_ID_ORDERS");
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__Stores__3B82F101878819E8");

                entity.ToTable("Stores", "Project0");

                entity.HasIndex(e => e.Location)
                    .HasName("UQ__Stores__E55D3B10F637588F")
                    .IsUnique();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ShippingCosts).HasColumnType("money");
            });
        }
    }
}
