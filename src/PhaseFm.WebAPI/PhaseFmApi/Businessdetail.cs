using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Businessdetail
{
    public int Id { get; set; }

    public string BusinessName { get; set; } = null!;

    public string StreetAddress { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Email { get; set; } = null!;
}
