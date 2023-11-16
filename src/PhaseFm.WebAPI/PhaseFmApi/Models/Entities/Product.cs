using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class Product : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public int ProductTypeId { get; set; }

  public int ProductCategoryId { get; set; }

  public string Name { get; set; } = null!;

  public string Description { get; set; } = null!;

  public decimal SellingPrice { get; set; }

  public decimal CostPrice { get; set; }

  public string PhotoPath { get; set; } = null!;

  public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

  public virtual ICollection<Orderline> Orderlines { get; set; } = new List<Orderline>();

  public virtual Productcategory ProductCategory { get; set; } = null!;

  public virtual Producttype ProductType { get; set; } = null!;

  public virtual ICollection<Productcolor> Productcolors { get; set; } = new List<Productcolor>();

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
