using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class Color : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public string Name { get; set; } = null!;

  public virtual ICollection<ProductColor> Productcolors { get; set; } = new List<ProductColor>();

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
