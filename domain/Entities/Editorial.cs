using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Editorial
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Campus { get; set; }
    // Navigation properties
    public ICollection<Book>? Books { get; set; }
}
