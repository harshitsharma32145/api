using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SixthTokenApi.Models
{
    public partial class sdirectdbContext : DbContext
    {
        public sdirectdbContext()
        {
        }

        public sdirectdbContext(DbContextOptions<sdirectdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Harshit20> Harshit20s { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.0.240;Database=sdirectdb;UID=sdirectdb;PWD=sdirectdb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Harshit20>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__harshit2__7AD04FF1F45DDA15");

                entity.ToTable("harshit20");

                entity.HasIndex(e => e.EmployeeEmail, "UQ__harshit2__616BAD37F2C2EED8")
                    .IsUnique();

                entity.HasIndex(e => e.EmployeePhoneNo, "UQ__harshit2__7BA6690A61773EDD")
                    .IsUnique();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Address");

                entity.Property(e => e.EmployeeAge).HasColumnName("Employee_Age");

                entity.Property(e => e.EmployeeEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Email");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Name");

                entity.Property(e => e.EmployeePhoneNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Employee_PhoneNo");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Login");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
