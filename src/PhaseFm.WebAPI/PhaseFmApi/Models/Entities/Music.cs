﻿using System;
using System.Collections.Generic;

namespace PhaseFmApi.Models.Entities;

public partial class Music : IDeletable, ICreatable, IUpdatable, IEntityPrimaryKey
{
  public int Id { get; set; }

  public string ArtistName { get; set; } = null!;

  public string Description { get; set; } = null!;

  public string SongName { get; set; } = null!;

  public string AlbumName { get; set; } = null!;

  public string Composer { get; set; } = null!;

  public string RecordLabel { get; set; } = null!;

  public DateOnly ReleaseDate { get; set; }

  public string FilePath { get; set; } = null!;

  public virtual ICollection<Playlistmusic> Playlistmusics { get; set; } = new List<Playlistmusic>();

	public DateTime? DateUpdated { get; set; }
	public DateTime DateCreated { get; set; }
	public bool IsDeleted { get; set; } = false;
	public DateTime? DateDeleted { get; set; }

	public object GetPrimaryKey()
	{
		return Id;
	}
}
