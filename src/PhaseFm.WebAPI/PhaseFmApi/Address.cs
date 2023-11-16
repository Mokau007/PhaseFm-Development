using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Address
{
    public int Id { get; set; }

    public string StreetName { get; set; } = null!;

    public string? ResidentialName { get; set; }

    public string? UnitNumber { get; set; }

    public string Suburb { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public virtual User IdNavigation { get; set; } = null!;
}
