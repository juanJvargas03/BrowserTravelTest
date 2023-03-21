using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class BookDTO
    {
        public long Isbn { get; set; }
        public int EditorialId { get; set; }
        public string Synopsis { get; set; }
        public string NPages { get; set; }
        public IEnumerable<int> AuthorsID { get; set; }
        public IEnumerable<BookAuthorDTO>? BookAuthors { get; set; }

    }
}
