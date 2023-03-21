using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class BookAuthor
{
    public long BookISBN { get; set; }
    public int AuthorId { get; set; }
    
    // Navigation properties
    public Author Author { get; set; }
    public Book Book { get; set; }
}

