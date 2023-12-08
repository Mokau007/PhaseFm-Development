using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class Show : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public string Name { get; set; } = null!;

  public string Description { get; set; } = null!;

  public TimeSpan StartTime { get; set; }

  public TimeSpan EndTime { get; set; }

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
