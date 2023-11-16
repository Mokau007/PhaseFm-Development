using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Quoteline
{
    public int Id { get; set; }

    public int QuotationId { get; set; }

    public string Name { get; set; } = null!;

    public decimal CostPerUnit { get; set; }

    public int Quantity { get; set; }

    public virtual Quotation Quotation { get; set; } = null!;
}
