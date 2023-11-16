using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class Musicrequest : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public int StatusId { get; set; }

  public string FirstName { get; set; } = null!;

  public string LastName { get; set; } = null!;

  public string Email { get; set; } = null!;

  public string ArtistName { get; set; } = null!;

  public string PhoneNumber { get; set; } = null!;

  public DateTime DateRequested { get; set; }

  public string Description { get; set; } = null!;

  public string SongName { get; set; } = null!;

  public virtual Musicrequeststatus Status { get; set; } = null!;

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
