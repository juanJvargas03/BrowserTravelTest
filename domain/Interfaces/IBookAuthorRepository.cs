using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces;
public interface IBookAuthorRepository
{
    Task<BookAuthor> CreateAsync(BookAuthor bookAuthor);
}
