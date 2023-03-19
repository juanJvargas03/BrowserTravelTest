using System;
using System.Collections.Generic;

namespace BrowserTravelTest.Models;

public partial class Book
{
    public long Isbn { get; set; }

    public int? EditorialId { get; set; }

    public string? Synopsis { get; set; }

    public string? NPages { get; set; }

    public virtual Editorial? Editorial { get; set; }

    public virtual ICollection<Author> Authors { get; } = new List<Author>();
}
