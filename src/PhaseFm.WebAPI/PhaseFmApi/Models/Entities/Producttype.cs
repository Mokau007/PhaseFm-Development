using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class Producttype : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public int ProductCategoryId { get; set; }

  public string Name { get; set; } = null!;

  public string Description { get; set; } = null!;

  public virtual Productcategory ProductCategory { get; set; } = null!;

  public virtual ICollection<Product> Products { get; set; } = new List<Product>();

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
