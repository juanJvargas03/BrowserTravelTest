using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> CreateAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(Author author);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
