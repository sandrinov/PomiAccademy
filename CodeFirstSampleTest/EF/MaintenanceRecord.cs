using System;
using System.Collections.Generic;

namespace CodeFirstSampleTest.EF;

public partial class MaintenanceRecord
{
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public DateTime ServiceDate { get; set; }

    public string? Description { get; set; }

    public decimal? Cost { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
}
