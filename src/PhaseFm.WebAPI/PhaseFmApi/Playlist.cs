using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Playlist
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Playlistmusic> Playlistmusics { get; set; } = new List<Playlistmusic>();
}
