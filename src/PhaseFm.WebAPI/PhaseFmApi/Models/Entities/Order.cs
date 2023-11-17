using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class Order : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public int UserId { get; set; }

  public DateOnly Date { get; set; }

	public DateOnly? DeliveryDate { get; set; }

	public decimal Amount { get; set; }

  public int OrderStatusId { get; set; }

  public int OrderReceivedStatusId { get; set; }

  public virtual Orderreceivedstatus OrderReceivedStatus { get; set; } = null!;

  public virtual Orderstatus OrderStatus { get; set; } = null!;

  public virtual User User { get; set; } = null!;

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}

}
