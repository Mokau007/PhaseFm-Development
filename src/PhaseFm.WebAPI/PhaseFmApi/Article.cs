using System;
using System.Collections.Generic;

namespace PhaseFmApi;

public partial class Article
{
    public int Id { get; set; }

    public DateTime DateGenerated { get; set; }

    public string ArticleContent { get; set; } = null!;
}
