using Domain.Entities;
using Domain.Interfaces;

public class EditorialRepository : Repository<Editorial>, IEditorialRepository
{
    public EditorialRepository(BrowserTravelTestDbContext dbContext) : base(dbContext)
    {
    }
}
