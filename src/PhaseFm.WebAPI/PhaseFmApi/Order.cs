using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public decimal Amount { get; set; }

    public int OrderStatusId { get; set; }

    public int OrderReceivedStatusId { get; set; }

    public virtual Orderreceivedstatus OrderReceivedStatus { get; set; } = null!;

    public virtual Orderstatus OrderStatus { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
