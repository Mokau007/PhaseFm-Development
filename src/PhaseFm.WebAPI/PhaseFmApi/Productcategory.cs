using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Productcategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Producttype> Producttypes { get; set; } = new List<Producttype>();
}
