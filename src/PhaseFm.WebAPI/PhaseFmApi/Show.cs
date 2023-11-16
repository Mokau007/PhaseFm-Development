using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Show
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public virtual ICollection<Radioshow> Radioshows { get; set; } = new List<Radioshow>();
}
