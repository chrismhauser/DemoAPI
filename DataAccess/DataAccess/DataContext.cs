using System;
using System.Collections.Generic;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.DataAccess
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrier> Carriers { get; set; } = null!;
        public virtual DbSet<PaymentTerm> PaymentTerms { get; set; } = null!;
        public virtual DbSet<Policy> Policies { get; set; } = null!;
        public virtual DbSet<PolicyStatus> PolicyStatuses { get; set; } = null!;
        public virtual DbSet<PolicyType> PolicyTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DemoAPI;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrier>(entity =>
            {
                entity.ToTable("Carrier");

                entity.Property(e => e.CarrierName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime")
                    .HasDefaultValue(DateTime.Today);
            });

            modelBuilder.Entity<PaymentTerm>(entity =>
            {
                entity.ToTable("PaymentTerm");

                entity.Property(e => e.DateCreated).HasColumnType("datetime")
                    .HasDefaultValue(DateTime.Today);

                entity.Property(e => e.PaymentTermName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PaymentTermName");
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.ToTable("Policy");

                entity.Property(e => e.PolicyId).UseIdentityColumn();

                entity.Property(e => e.DateCreated).HasColumnType("datetime")
                    .HasDefaultValue(DateTime.Today);

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.Property(e => e.PolicyNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Carrier)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.CarrierId)
                    .OnDelete(DeleteBehavior.ClientNoAction)
                    .HasConstraintName("FK_Policy_Carrier");

                entity.HasOne(d => d.PaymentTerm)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.PaymentTermId)
                    .OnDelete(DeleteBehavior.ClientNoAction)
                    .HasConstraintName("FK_Policy_PaymentTerm");

                entity.HasOne(d => d.PolicyStatus)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.PolicyStatusId)
                    .OnDelete(DeleteBehavior.ClientNoAction)
                    .HasConstraintName("FK_Policy_PolicyStatus");

                entity.HasOne(d => d.PolicyType)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.PolicyTypeId)
                    .OnDelete(DeleteBehavior.ClientNoAction)
                    .HasConstraintName("FK_Policy_PolicyType");
            });

            modelBuilder.Entity<PolicyStatus>(entity =>
            {
                entity.ToTable("PolicyStatus");

                entity.Property(e => e.DateCreated).HasColumnType("datetime")
                    .HasDefaultValue(DateTime.Today);

                entity.Property(e => e.PolicyStatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PolicyStatusName");
            });

            modelBuilder.Entity<PolicyType>(entity =>
            {
                entity.ToTable("PolicyType");

                entity.Property(e => e.DateCreated).HasColumnType("datetime")
                    .HasDefaultValue(DateTime.Today);

                entity.Property(e => e.PolicyTypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PolicyTypeName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
