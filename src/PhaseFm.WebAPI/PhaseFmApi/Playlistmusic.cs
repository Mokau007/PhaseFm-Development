using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Playlistmusic
{
    public int Id { get; set; }

    public int PlayListId { get; set; }

    public int MusicId { get; set; }

    public virtual Music Music { get; set; } = null!;

    public virtual Playlist PlayList { get; set; } = null!;
}
