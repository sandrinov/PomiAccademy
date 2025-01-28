using System;
using System.Collections.Generic;

namespace CodeFirstSampleTest.EF;

public partial class Driver
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string LicenseNumber { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
