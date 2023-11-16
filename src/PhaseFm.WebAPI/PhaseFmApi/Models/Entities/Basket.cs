using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class Basket : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public int ProductId { get; set; }

  public int UserId { get; set; }

  public int Quantity { get; set; }

  public virtual Product Product { get; set; } = null!;

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
