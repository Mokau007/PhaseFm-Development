using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Musicrequeststatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Musicrequest> Musicrequests { get; set; } = new List<Musicrequest>();
}
