using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Product
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
}
