using Domain.Entities;
using Domain.Interfaces;
using Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.DTO;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await _bookRepository.GetAllAsync();
    }

    public async Task<Book> GetBookByIdAsync(long id)
    {
        return await _bookRepository.GetByIdAsync(id);
    }

    public async Task<Book> CreateBookAsync(BookDTO bookDTO)
    {
        if (bookDTO.AuthorsID == null || bookDTO.AuthorsID.Count() == 0) throw new ArgumentNullException("At least one 'Author' is required for a book");

        Book book = new Book();
        book.Isbn = bookDTO.Isbn;
        book.EditorialId = bookDTO.EditorialId;
        book.Synopsis = bookDTO.Synopsis;
        book.NPages = bookDTO.NPages;

        if (book == null) throw new ArgumentNullException("The 'Book' is required");

        return await _bookRepository.AddAsync(book);
    }

    public async Task<Book> UpdateBookAsync(Book book)
    {
        if (book == null) throw new ArgumentNullException("The 'Book' is required");

        return await _bookRepository.UpdateAsync(book);
    }

    public async Task<bool> DeleteBookAsync(long id)
    {
        return await _bookRepository.DeleteAsync(id);
    }
}