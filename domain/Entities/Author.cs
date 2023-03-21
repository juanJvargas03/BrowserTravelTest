using Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Author
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public ICollection<BookAuthor>? BookAuthors { get; set; }
}
