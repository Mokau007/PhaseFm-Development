using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Color
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Productcolor> Productcolors { get; set; } = new List<Productcolor>();
}
