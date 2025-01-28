using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstSampleTest.EF;

public partial class FleetDBContext : DbContext
{
    public FleetDBContext()
    {
    }

    public FleetDBContext(DbContextOptions<FleetDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<FuelLog> FuelLogs { get; set; }

    public virtual DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:sqlservercboxtest.database.windows.net,1433;Database=FleetManagementSystemDB;User ID=pomi-admin;Password=Addtech2021!;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Drivers__3214EC0790415C0F");

            entity.HasIndex(e => e.LicenseNumber, "UQ__Drivers__E88901665A03BEE6").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.LicenseNumber).HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<FuelLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FuelLogs__3214EC07DD0DA4C0");

            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FuelAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Odometer).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RefuelDate).HasColumnType("datetime");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.FuelLogs)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK__FuelLogs__Vehicl__76969D2E");
        });

        modelBuilder.Entity<MaintenanceRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Maintena__3214EC07880A0B0C");

            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.ServiceDate).HasColumnType("datetime");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.MaintenanceRecords)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK__Maintenan__Vehic__73BA3083");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trips__3214EC07934FF5CD");

            entity.Property(e => e.Distance).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EndLocation).HasMaxLength(100);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartLocation).HasMaxLength(100);
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Driver).WithMany(p => p.Trips)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK__Trips__DriverId__70DDC3D8");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Trips)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK__Trips__VehicleId__6FE99F9F");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehicles__3214EC078604D347");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CurrentMileage).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.LicensePlate).HasMaxLength(20);
            entity.Property(e => e.Manufacturer).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.VehicleColor).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
