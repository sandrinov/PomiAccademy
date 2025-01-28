using System;
using System.Collections.Generic;

namespace CodeFirstSampleTest.EF;

public partial class FuelLog
{
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public DateTime RefuelDate { get; set; }

    public decimal? FuelAmount { get; set; }

    public decimal? Cost { get; set; }

    public decimal? Odometer { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
}
