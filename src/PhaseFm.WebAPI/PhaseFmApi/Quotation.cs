using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Quotation
{
    public int Id { get; set; }

    public DateTime DateCreated { get; set; }

    public string ClientName { get; set; } = null!;

    public string ClientAddress { get; set; } = null!;

    public virtual ICollection<Quoteline> Quotelines { get; set; } = new List<Quoteline>();
}
