using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Radio
{
    public int Id { get; set; }

    public string Day { get; set; } = null!;

    public virtual ICollection<Radioshow> Radioshows { get; set; } = new List<Radioshow>();
}
