using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DTO;
using System.Threading.Tasks;

public class BookAuthorService : IBookAuthorService
{
    private readonly IBookAuthorRepository _bookAuthorRepository;

    public BookAuthorService(IBookAuthorRepository bookAuthorRepository)
    {
        _bookAuthorRepository = bookAuthorRepository;
    }

    public async Task<BookAuthor> CreateAsync(BookDTO bookDTO, Book book)
    {
        var response = new BookAuthor();
        foreach (var id in bookDTO.AuthorsID)
        {
            var bookAuthor = new BookAuthor();
            bookAuthor.AuthorId = id;
            bookAuthor.BookISBN = book.Isbn;
            response = await _bookAuthorRepository.CreateAsync(bookAuthor);

        }
        
        return response;
    }
}