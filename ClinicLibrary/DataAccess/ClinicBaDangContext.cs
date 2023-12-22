using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClinicLibrary.DataAccess;

public partial class ClinicBaDangContext : DbContext
{
    public ClinicBaDangContext()
    {
    }

    public ClinicBaDangContext(DbContextOptions<ClinicBaDangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DoctorDetail> DoctorDetails { get; set; }

    public virtual DbSet<Speccialization> Speccializations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-IVHRL9V;Database=Clinic_BaDang;User Id=testuser;Password=abc123!@#;TrustServerCertificate=true;Trusted_Connection=SSPI;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("Doctor");

            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<DoctorDetail>(entity =>
        {
            entity.HasKey(e => e.DoctorId);

            entity.ToTable("DoctorDetail");

            entity.Property(e => e.DoctorId)
                .ValueGeneratedNever()
                .HasColumnName("DoctorID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.DoctorName).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.SpecializatioId).HasColumnName("SpecializatioID");

            entity.HasOne(d => d.Doctor).WithOne(p => p.DoctorDetail)
                .HasForeignKey<DoctorDetail>(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoctorDetail_DoctorDetail");

            entity.HasOne(d => d.Specializatio).WithMany(p => p.DoctorDetails)
                .HasForeignKey(d => d.SpecializatioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoctorDetail_Speccialization");
        });

        modelBuilder.Entity<Speccialization>(entity =>
        {
            entity.ToTable("Speccialization");

            entity.Property(e => e.SpeccializationName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
