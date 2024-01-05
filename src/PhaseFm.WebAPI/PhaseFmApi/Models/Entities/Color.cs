using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhaseFmApi.Models.Entities;

public partial class Color : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
	[Key]
	public int Id { get; set; }

  public string Name { get; set; } = null!;

	public string ColorCode { get; set; } = null!;

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
