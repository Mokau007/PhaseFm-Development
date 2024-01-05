using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhaseFmApi.Models.Entities;

public partial class ProductType : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
	[Key]
	public int Id { get; set; }

  public int ProductCategoryId { get; set; }

  public string Name { get; set; } = null!;

  public string Description { get; set; } = null!;

  public virtual ProductCategory ProductCategory { get; set; } = null!;

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
