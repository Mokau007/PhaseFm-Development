using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhaseFmApi.Models.Entities;

public partial class Quotation : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
	[Key]
	public int Id { get; set; }

  public DateOnly DateGenerated { get; set; }

  public string ClientName { get; set; } = null!;

  public string ClientAddress { get; set; } = null!;

  public virtual ICollection<Quoteline> Quotelines { get; set; } = new List<Quoteline>();

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
