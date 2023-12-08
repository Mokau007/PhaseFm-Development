using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class ProductCategory : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public string Name { get; set; } = null!;

  public string Description { get; set; } = null!;

  public virtual ICollection<Product> Products { get; set; } = new List<Product>();

  public virtual ICollection<ProductType> Producttypes { get; set; } = new List<ProductType>();

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
