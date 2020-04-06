using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dineIN.Models
{
    public partial class DINE_INContext : DbContext
    {
        public DINE_INContext()
        {
        }

        public DINE_INContext(DbContextOptions<DINE_INContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Dishes> Dishes { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost,1433; Database=DINE_IN;User Id=sa;Password=reallyStrongPwd123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("Customers_PK");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customerId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DishName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.DishNameNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.DishName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Customers_FK");
            });

            modelBuilder.Entity<Dishes>(entity =>
            {
                entity.HasKey(e => e.DishName)
                    .HasName("Dishes_PK");

                entity.Property(e => e.DishName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DishDetails)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DishId)
                    .HasColumnName("dishId")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.HasKey(e => e.ReservationId)
                    .HasName("Reservations_PK");

                entity.Property(e => e.ReservationId).HasColumnName("reservationId");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reservations_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
