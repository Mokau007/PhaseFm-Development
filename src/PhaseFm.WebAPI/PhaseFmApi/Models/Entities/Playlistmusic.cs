using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class Playlistmusic : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public int PlayListId { get; set; }

  public int MusicId { get; set; }

  public virtual Music Music { get; set; } = null!;

  public virtual Playlist PlayList { get; set; } = null!;

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
