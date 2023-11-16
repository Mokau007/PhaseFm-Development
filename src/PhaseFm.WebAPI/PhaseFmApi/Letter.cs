using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Letter
{
    public int Id { get; set; }

    public string RecipientName { get; set; } = null!;

    public string RecipientLastName { get; set; } = null!;

    public DateTime DateGenerated { get; set; }

    public string LetterContent { get; set; } = null!;
}
