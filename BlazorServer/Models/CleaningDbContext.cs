using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorServer.Models
{
    public partial class CleaningDbContext : DbContext
    {
        public CleaningDbContext()
        {
        }

        public CleaningDbContext(DbContextOptions<CleaningDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bid> Bids { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<StatusBid> StatusBids { get; set; } = null!;
        public virtual DbSet<StatusEmployee> StatusEmployees { get; set; } = null!;
        public virtual DbSet<StatusOrder> StatusOrders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=HOME-PC;Database=CleaningDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bid>(entity =>
            {
                entity.Property(e => e.DatePerfomance).HasColumnType("date");

                entity.Property(e => e.DateSubmission).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Bids)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bids_Clients");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.Bids)
                    .HasForeignKey(d => d.IdService)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bids_Services");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Bids)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bids_StatusBid");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Blog1)
                    .HasMaxLength(500)
                    .HasColumnName("Blog");

                entity.Property(e => e.DatePublish).HasMaxLength(500);

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blogs_Employees");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_EmployeeStatuses");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DateBeginning).HasColumnType("date");

                entity.Property(e => e.DateEnd).HasColumnType("date");

                entity.Property(e => e.IdClient).HasMaxLength(50);

                entity.Property(e => e.PriceOrder).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Employees");

                entity.HasOne(d => d.IdB)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdBid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Bids");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_StatusOrder");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.DatePublish).HasColumnType("date");

                entity.Property(e => e.ReviewText).HasMaxLength(500);

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_Clients");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CostService).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DescriptionService).HasMaxLength(200);

                entity.Property(e => e.TitleService).HasMaxLength(50);
            });

            modelBuilder.Entity<StatusBid>(entity =>
            {
                entity.ToTable("StatusBid");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<StatusEmployee>(entity =>
            {
                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<StatusOrder>(entity =>
            {
                entity.ToTable("StatusOrder");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
