using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Productcolor
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ColorId { get; set; }

    public virtual Color Color { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
