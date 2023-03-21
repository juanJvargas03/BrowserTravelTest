using Domain.Entities;
using Domain.Interfaces;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    public AuthorRepository(BrowserTravelTestDbContext dbContext) : base(dbContext)
    {
    }
}
