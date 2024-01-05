using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhaseFmApi.Models.Entities;

public partial class MusicSubmissionStatus : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
	[Key]
	public int Id { get; set; }

  public string Name { get; set; } = null!;

  public string Description { get; set; } = null!;

  public virtual ICollection<MusicSubmission> Musicsubmissions { get; set; } = new List<MusicSubmission>();

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
