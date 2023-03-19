using System;
using System.Collections.Generic;

namespace BrowserTravelTest.Models;

public partial class Author
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public virtual ICollection<Book> BookIsbns { get; } = new List<Book>();
}
