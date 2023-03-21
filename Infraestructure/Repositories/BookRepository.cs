using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(BrowserTravelTestDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<bool> DeleteAsync(long id)
    {
        var book = await _dbContext.Books
            .Include(b => b.BookAuthors)
            .FirstOrDefaultAsync(b => b.Isbn == id);

        if (book == null)
        {
            return false;
        }

        _dbContext.BookAuthors.RemoveRange(book.BookAuthors);

        return await base.DeleteAsync(id);
    }
}