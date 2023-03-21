using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class BookAuthorRepository : IBookAuthorRepository
{
    private readonly BrowserTravelTestDbContext _dbContext;

    public BookAuthorRepository(BrowserTravelTestDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<BookAuthor> CreateAsync(BookAuthor bookAuthor)
    {
        _dbContext.BookAuthors.Add(bookAuthor);
        await _dbContext.SaveChangesAsync();
        return bookAuthor;
    }
}