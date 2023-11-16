using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Orderreceivedstatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
