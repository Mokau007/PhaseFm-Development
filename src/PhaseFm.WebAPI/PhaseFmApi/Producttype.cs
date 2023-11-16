using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Producttype
{
    public int Id { get; set; }

    public int ProductCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual Productcategory ProductCategory { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
