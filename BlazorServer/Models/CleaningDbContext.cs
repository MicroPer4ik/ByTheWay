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

        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServiceType> ServiceTypes { get; set; } = null!;
        public virtual DbSet<StatusEmployee> StatusEmployees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=HOME-PC;Database=CleaningDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

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

                entity.Property(e => e.DateSubmission).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.PriceOrder).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Orders_Employees");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Clients");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_OrderStatus");

                entity.HasMany(d => d.IdServices)
                    .WithMany(p => p.IdOrders)
                    .UsingEntity<Dictionary<string, object>>(
                        "OrderService",
                        l => l.HasOne<Service>().WithMany().HasForeignKey("IdService").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OrderService_Services"),
                        r => r.HasOne<Order>().WithMany().HasForeignKey("IdOrder").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OrderService_Orders"),
                        j =>
                        {
                            j.HasKey("IdOrder", "IdService");

                            j.ToTable("OrderService");
                        });
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus");

                entity.Property(e => e.StatusName).HasMaxLength(50);
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
                entity.Property(e => e.CostService).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TitleService).HasMaxLength(50);

                entity.HasOne(d => d.IdServiceTypeNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.IdServiceType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_ServiceTypes");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.Property(e => e.TypeTitle).HasMaxLength(50);
            });

            modelBuilder.Entity<StatusEmployee>(entity =>
            {
                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
