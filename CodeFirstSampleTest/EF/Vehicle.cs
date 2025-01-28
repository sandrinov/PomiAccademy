using System;
using System.Collections.Generic;

namespace CodeFirstSampleTest.EF;

public partial class Vehicle
{
    public int Id { get; set; }

    public string LicensePlate { get; set; } = null!;

    public string? Model { get; set; }

    public string? Manufacturer { get; set; }

    public int? Year { get; set; }

    public decimal? CurrentMileage { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? VehicleColor { get; set; }

    public virtual ICollection<FuelLog> FuelLogs { get; set; } = new List<FuelLog>();

    public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
