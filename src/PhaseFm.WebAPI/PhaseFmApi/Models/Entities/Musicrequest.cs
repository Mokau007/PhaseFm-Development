using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhaseFmApi.Models.Entities;

public partial class MusicRequest : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
	[Key]
	public int Id { get; set; }

  public int StatusId { get; set; }

  public string FirstName { get; set; } = null!;

  public string LastName { get; set; } = null!;

  public string Email { get; set; } = null!;

  public string ArtistName { get; set; } = null!;

  public string PhoneNumber { get; set; } = null!;

  public DateOnly DateRequested { get; set; }

  public string Description { get; set; } = null!;

  public string SongName { get; set; } = null!;

  public virtual MusicRequestStatus Status { get; set; } = null!;

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
