using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhaseFmApi.Models.Entities;

public partial class Address: IDeletable,ICreatable,IUpdatable,IEntityPrimaryKey
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	[ForeignKey("User")]
	public int UserId { get; set; }

  public string StreetName { get; set; } = null!;

  public string? ResidentialName { get; set; }

  public string? UnitNumber { get; set; }

  public string Suburb { get; set; } = null!;

  public string City { get; set; } = null!;

  public string Province { get; set; } = null!;

  public string Country { get; set; } = null!;

  public string PostalCode { get; set; } = null!;

  public virtual User User { get; set; } = null!;
  public DateTime? DateUpdated { get; set; }
  public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
  public DateTime? DateDeleted { get; set; }

  public object GetPrimaryKey()
  {
		return Id;
  }
}
