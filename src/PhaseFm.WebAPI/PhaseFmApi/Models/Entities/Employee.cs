using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhaseFmApi.Models.Entities;

public partial class Employee : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
	[Key]
	public int Id { get; set; }

  public int EmployeeTypeId { get; set; }

  public string FirstName { get; set; } = null!;

  public string LastName { get; set; } = null!;

  public string Email { get; set; } = null!;

  public string PhoneNumber { get; set; } = null!;

  public string Address { get; set; } = null!;

  public virtual EmployeeType EmployeeType { get; set; } = null!;

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
