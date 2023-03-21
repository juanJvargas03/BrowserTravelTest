using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;
using Infrastructure.DTO;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(long id);
        Task<Book> CreateBookAsync(BookDTO bookDTO);
        Task<Book> UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(long id);
    }
}
