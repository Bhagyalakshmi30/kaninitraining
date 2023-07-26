using System;
using System.Collections.Generic;
using BloodDB.Model;
using Microsoft.EntityFrameworkCore;

namespace BloodDB.Model;

public partial class BloodDbContext : DbContext
{
   

    public BloodDbContext(DbContextOptions<BloodDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Donor> Donors { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Donor>(entity =>
        {
            entity.HasKey(e => e.Donorid).HasName("PK__Donors__053133A05FCBB78A");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.BloodGroup).HasMaxLength(15);
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Firstname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phone).HasMaxLength(12);

            entity.HasOne(d => d.EmpassitNavigation).WithMany(p => p.Donors)
                .HasForeignKey(d => d.Empassit)
                .HasConstraintName("FK__Donors__Empassit__4222D4EF");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Empid).HasName("PK__Employee__AF2EBFA1717C2998");

            entity.ToTable("Employee");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Empname)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Fullname)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(12);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
