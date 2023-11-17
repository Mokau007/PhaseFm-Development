using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class Vat : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public decimal? Percentage { get; set; }

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
