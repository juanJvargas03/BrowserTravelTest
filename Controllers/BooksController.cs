using Application.Interfaces;
using Domain.Entities;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IBookAuthorService _bookAuthorService;

    public BooksController(IBookService bookService, IBookAuthorService bookAuthorService)
    {
        _bookService = bookService;
        _bookAuthorService = bookAuthorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _bookService.GetBooksAsync();
        return Ok(books);
    }

    [HttpGet("{isbn}")]
    public async Task<IActionResult> GetBookById(long isbn)
    {
        var book = await _bookService.GetBookByIdAsync(isbn);
        if (book == null) return NotFound();

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(BookDTO bookDTO)
    {
        
        var createdBook = await _bookService.CreateBookAsync(bookDTO);


        var createdBookAuthor = await _bookAuthorService.CreateAsync(bookDTO, createdBook);
        
        var createdBookDto = new BookDTO
        {
            Isbn = createdBook.Isbn,
            EditorialId = createdBook.EditorialId,
            Synopsis = createdBook.Synopsis,
            NPages = createdBook.NPages,
            BookAuthors = bookDTO.BookAuthors
        };

        return CreatedAtAction(nameof(GetBookById), new { isbn = createdBookDto.Isbn }, createdBookDto);
    }

    [HttpPut("{isbn}")]
    public async Task<IActionResult> UpdateBook(long isbn, Book book)
    {
        if (isbn != book.Isbn) return BadRequest();

        var updatedBook = await _bookService.UpdateBookAsync(book);
        if (updatedBook == null) return NotFound();

        return NoContent();
    }

    [HttpDelete("{isbn}")]
    public async Task<IActionResult> DeleteBook(long isbn)
    {
        var result = await _bookService.DeleteBookAsync(isbn);
        if (!result) return NotFound();

        return NoContent();
    }
}
