﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhaseFmApi.Models.Entities;

public partial class Product : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
	[Key]
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

  public virtual ProductCategory ProductCategory { get; set; } = null!;

  public virtual ProductType ProductType { get; set; } = null!;

  public virtual ICollection<ProductColor> Productcolors { get; set; } = new List<ProductColor>();

	public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();


	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
