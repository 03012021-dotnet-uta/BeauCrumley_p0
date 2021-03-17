using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Pizzabox.Storing.dbModels
{
    public partial class PizzaboxDBContext : DbContext
    {
        public PizzaboxDBContext()
        {
        }

        public PizzaboxDBContext(DbContextOptions<PizzaboxDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CrustOption> CrustOptions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PizzaHistory> PizzaHistories { get; set; }
        public virtual DbSet<PizzaHistoryJunction> PizzaHistoryJunctions { get; set; }
        public virtual DbSet<PresetPizza> PresetPizzas { get; set; }
        public virtual DbSet<PresetPizzaJunction> PresetPizzaJunctions { get; set; }
        public virtual DbSet<SauceOption> SauceOptions { get; set; }
        public virtual DbSet<SizeOption> SizeOptions { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=PizzaboxDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CrustOption>(entity =>
            {
                entity.HasKey(e => e.CrustId)
                    .HasName("PK__CrustOpt__D8C84C3550AF54EE");

                entity.Property(e => e.CrustId).HasColumnName("CrustID");

                entity.Property(e => e.CrustOptionName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CrustOptionPrice).HasColumnType("decimal(4, 2)");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.TotalSale).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Customer)
                    .HasConstraintName("FK__Orders__Customer__4AB81AF0");

                entity.HasOne(d => d.FulfillingStoreNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.FulfillingStore)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Orders__Fulfilli__49C3F6B7");
            });

            modelBuilder.Entity<PizzaHistory>(entity =>
            {
                entity.HasKey(e => e.PizzaId)
                    .HasName("PK__PizzaHis__0B6012FD4B6DC624");

                entity.ToTable("PizzaHistory");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PizzaHistories)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PizzaHist__Order__4D94879B");
            });

            modelBuilder.Entity<PizzaHistoryJunction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PizzaHistoryJunction");

                entity.Property(e => e.CrustId).HasColumnName("CrustID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.SauceId).HasColumnName("SauceID");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.ToppingId).HasColumnName("ToppingID");

                entity.HasOne(d => d.Crust)
                    .WithMany()
                    .HasForeignKey(d => d.CrustId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PizzaHist__Crust__5070F446");

                entity.HasOne(d => d.Pizza)
                    .WithMany()
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PizzaHist__Pizza__4F7CD00D");

                entity.HasOne(d => d.Sauce)
                    .WithMany()
                    .HasForeignKey(d => d.SauceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PizzaHist__Sauce__5165187F");

                entity.HasOne(d => d.Size)
                    .WithMany()
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PizzaHist__SizeI__52593CB8");

                entity.HasOne(d => d.Topping)
                    .WithMany()
                    .HasForeignKey(d => d.ToppingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PizzaHist__Toppi__534D60F1");
            });

            modelBuilder.Entity<PresetPizza>(entity =>
            {
                entity.HasKey(e => e.PizzaId)
                    .HasName("PK__PresetPi__0B6012FD3ED3C11E");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.PizzaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PresetPizzaJunction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PresetPizzaJunction");

                entity.Property(e => e.CrustId).HasColumnName("CrustID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.SauceId).HasColumnName("SauceID");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.ToppingId).HasColumnName("ToppingID");

                entity.HasOne(d => d.Crust)
                    .WithMany()
                    .HasForeignKey(d => d.CrustId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PresetPiz__Crust__4222D4EF");

                entity.HasOne(d => d.Pizza)
                    .WithMany()
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PresetPiz__Pizza__412EB0B6");

                entity.HasOne(d => d.Sauce)
                    .WithMany()
                    .HasForeignKey(d => d.SauceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PresetPiz__Sauce__4316F928");

                entity.HasOne(d => d.Size)
                    .WithMany()
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PresetPiz__SizeI__440B1D61");

                entity.HasOne(d => d.Topping)
                    .WithMany()
                    .HasForeignKey(d => d.ToppingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PresetPiz__Toppi__44FF419A");
            });

            modelBuilder.Entity<SauceOption>(entity =>
            {
                entity.HasKey(e => e.SauceId)
                    .HasName("PK__SauceOpt__667BC48311370C4F");

                entity.Property(e => e.SauceId).HasColumnName("SauceID");

                entity.Property(e => e.SauceOptionName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SizeOption>(entity =>
            {
                entity.HasKey(e => e.SizeId)
                    .HasName("PK__SizeOpti__83BD095AF39AE71A");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.SizeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SizePrice).HasColumnType("decimal(4, 2)");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.OpperationHourEnd)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.OpperationHourStart)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.StoreAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.Property(e => e.ToppingId).HasColumnName("ToppingID");

                entity.Property(e => e.ToppingName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToppingPrice).HasColumnType("decimal(4, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
