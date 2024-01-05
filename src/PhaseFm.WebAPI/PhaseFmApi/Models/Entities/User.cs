using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhaseFmApi.Models.Entities;

public partial class User : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
	[Key]
	public int Id { get; set; }

  public string FirstName { get; set; } = null!;

  public string LastName { get; set; } = null!;

  public string Email { get; set; } = null!;

  public string Password { get; set; } = null!;

  public string PhoneNumber { get; set; } = null!;

	public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

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
