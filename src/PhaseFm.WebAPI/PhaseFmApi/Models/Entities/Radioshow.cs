using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class Radioshow : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public int RadioId { get; set; }

  public int ShowId { get; set; }

  public virtual Radio Radio { get; set; } = null!;

  public virtual Show Show { get; set; } = null!;

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
