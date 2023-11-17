using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class Orderline : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public int ProductId { get; set; }

  public int ProductQuantity { get; set; }

  public virtual Product Product { get; set; } = null!;

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
