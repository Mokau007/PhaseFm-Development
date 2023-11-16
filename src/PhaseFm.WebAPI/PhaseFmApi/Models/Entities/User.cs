using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class User : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public string FirstName { get; set; } = null!;

  public string LastName { get; set; } = null!;

  public string Email { get; set; } = null!;

  public string Password { get; set; } = null!;

  public string PhoneNumber { get; set; } = null!;

  public virtual Address? Address { get; set; }

  public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

  public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
