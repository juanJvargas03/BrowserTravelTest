using Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Book
{
    [Key]
    public long Isbn { get; set; }
    public int EditorialId { get; set; }
    public string Synopsis { get; set; }
    public string NPages { get; set; }
    // Navigation properties
    public Editorial Editorial { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }

}