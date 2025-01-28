using System;
using System.Collections.Generic;

namespace CodeFirstSampleTest.EF;

public partial class Trip
{
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public int DriverId { get; set; }

    public string? StartLocation { get; set; }

    public string? EndLocation { get; set; }

    public decimal? Distance { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual Vehicle Vehicle { get; set; } = null!;
}
