using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Musicsubmission
{
    public int Id { get; set; }

    public int StatusId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string ArtistName { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string Composer { get; set; } = null!;

    public string RecordLabel { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public string Description { get; set; } = null!;

    public string SongName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public virtual Musicsubmissionstatus Status { get; set; } = null!;
}
