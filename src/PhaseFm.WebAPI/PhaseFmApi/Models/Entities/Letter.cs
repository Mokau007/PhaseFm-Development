using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class Letter : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public string RecipientName { get; set; } = null!;

  public string RecipientLastName { get; set; } = null!;

  public DateTime DateGenerated { get; set; }

  public string LetterContent { get; set; } = null!;

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
