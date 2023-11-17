using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class Quoteline : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public int QuotationId { get; set; }

  public string Name { get; set; } = null!;

  public decimal CostPerUnit { get; set; }

  public int Quantity { get; set; }

  public virtual Quotation Quotation { get; set; } = null!;

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
