using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhaseFmApi.Models.Entities;

public partial class Radio : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
	[Key]
  public int Id { get; set; }

  public string Day { get; set; } = null!;

  public virtual ICollection<RadioShow> Radioshows { get; set; } = new List<RadioShow>();

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
