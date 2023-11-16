using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Radioshow
{
    public int Id { get; set; }

    public int RadioId { get; set; }

    public int ShowId { get; set; }

    public virtual Radio Radio { get; set; } = null!;

    public virtual Show Show { get; set; } = null!;
}
