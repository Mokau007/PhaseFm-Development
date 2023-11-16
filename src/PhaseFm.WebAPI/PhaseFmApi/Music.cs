using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Music
{
    public int Id { get; set; }

    public string ArtistName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string SongName { get; set; } = null!;

    public string AlbumName { get; set; } = null!;

    public string Composer { get; set; } = null!;

    public string RecordLabel { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public string FilePath { get; set; } = null!;

    public virtual ICollection<Playlistmusic> Playlistmusics { get; set; } = new List<Playlistmusic>();
}
