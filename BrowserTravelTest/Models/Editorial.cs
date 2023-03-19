using System;
using System.Collections.Generic;

namespace BrowserTravelTest.Models;

public partial class Editorial
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Campus { get; set; }

    public virtual ICollection<Book> Books { get; } = new List<Book>();
}
