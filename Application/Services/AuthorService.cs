using Domain.Entities;
using Domain.Interfaces;
using Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await _authorRepository.GetAllAsync();
    }

    public async Task<Author> GetAuthorByIdAsync(int id)
    {
        return await _authorRepository.GetByIdAsync(id);
    }

    public async Task<Author> CreateAuthorAsync(Author author)
    {
        if (author == null) throw new ArgumentNullException("The 'Author' is required");

        return await _authorRepository.AddAsync(author);
    }

    public async Task<Author> UpdateAuthorAsync(Author author)
    {
        if (author == null) throw new ArgumentNullException("The 'Author' is required");

        return await _authorRepository.UpdateAsync(author);
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {
        return await _authorRepository.DeleteAsync(id);
    }
}