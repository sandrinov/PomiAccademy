﻿// <auto-generated />
using System;
using CodeFirstSampleTest.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeFirstSampleTest.Migrations
{
    [DbContext(typeof(FleetDBContext))]
    partial class FleetDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodeFirstSampleTest.EF.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id")
                        .HasName("PK__Drivers__3214EC0790415C0F");

                    b.HasIndex(new[] { "LicenseNumber" }, "UQ__Drivers__E88901665A03BEE6")
                        .IsUnique();

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("CodeFirstSampleTest.EF.FuelLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("FuelAmount")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("Odometer")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime>("RefuelDate")
                        .HasColumnType("datetime");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__FuelLogs__3214EC07DD0DA4C0");

                    b.HasIndex("VehicleId");

                    b.ToTable("FuelLogs");
                });

            modelBuilder.Entity("CodeFirstSampleTest.EF.MaintenanceRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("ServiceDate")
                        .HasColumnType("datetime");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Maintena__3214EC07880A0B0C");

                    b.HasIndex("VehicleId");

                    b.ToTable("MaintenanceRecords");
                });

            modelBuilder.Entity("CodeFirstSampleTest.EF.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Distance")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("EndLocation")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<string>("StartLocation")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Trips__3214EC07934FF5CD");

                    b.HasIndex("DriverId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("CodeFirstSampleTest.EF.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<decimal?>("CurrentMileage")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("VehicleColor")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Vehicles__3214EC078604D347");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CodeFirstSampleTest.EF.FuelLog", b =>
                {
                    b.HasOne("CodeFirstSampleTest.EF.Vehicle", "Vehicle")
                        .WithMany("FuelLogs")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__FuelLogs__Vehicl__76969D2E");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CodeFirstSampleTest.EF.MaintenanceRecord", b =>
                {
                    b.HasOne("CodeFirstSampleTest.EF.Vehicle", "Vehicle")
                        .WithMany("MaintenanceRecords")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Maintenan__Vehic__73BA3083");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CodeFirstSampleTest.EF.Trip", b =>
                {
                    b.HasOne("CodeFirstSampleTest.EF.Driver", "Driver")
                        .WithMany("Trips")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Trips__DriverId__70DDC3D8");

                    b.HasOne("CodeFirstSampleTest.EF.Vehicle", "Vehicle")
                        .WithMany("Trips")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Trips__VehicleId__6FE99F9F");

                    b.Navigation("Driver");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CodeFirstSampleTest.EF.Driver", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("CodeFirstSampleTest.EF.Vehicle", b =>
                {
                    b.Navigation("FuelLogs");

                    b.Navigation("MaintenanceRecords");

                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
