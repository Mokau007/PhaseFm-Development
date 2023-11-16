using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Musicsubmissionstatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Musicsubmission> Musicsubmissions { get; set; } = new List<Musicsubmission>();
}
