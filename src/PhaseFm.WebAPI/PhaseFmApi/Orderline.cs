using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Orderline
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ProductQuantity { get; set; }

    public virtual Product Product { get; set; } = null!;
}
