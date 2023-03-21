using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DTO;


public class BookServiceTests
{
    private readonly Mock<IBookRepository> _mockBookRepository;
    private readonly IBookService _bookService;

    public BookServiceTests()
    {
        _mockBookRepository = new Mock<IBookRepository>();
        _bookService = new BookService(_mockBookRepository.Object);
    }

    [Fact]
    public async Task CreateBookAsync_ShouldCreateBookAndAuthors()
    {
        // Arrange
        var bookDto = new BookDTO
        {
            Isbn = 1234567890,
            EditorialId = 1,
            Synopsis = "Test Synopsis",
            NPages = "100",
            AuthorsID = new List<int> { 1, 2 }
        };

        _mockBookRepository.Setup(r => r.AddAsync(It.IsAny<Book>()))
                           .ReturnsAsync((Book b) => b);

        // Act
        var result = await _bookService.CreateBookAsync(bookDto);

        // Assert
        _mockBookRepository.Verify(r => r.AddAsync(It.IsAny<Book>()), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(bookDto.Isbn, result.Isbn);
        Assert.Equal(bookDto.EditorialId, result.EditorialId);
        Assert.Equal(bookDto.Synopsis, result.Synopsis);
        Assert.Equal(bookDto.NPages, result.NPages);
    }

    [Fact]
    public async Task GetBookByIdAsync_ShouldReturnBook()
    {
        // Arrange
        var book = new Book
        {
            Isbn = 1234567890,
            EditorialId = 1,
            Synopsis = "Test Synopsis",
            NPages = "100",
            BookAuthors = new List<BookAuthor>
        {
            new BookAuthor { AuthorId = 1 },
            new BookAuthor { AuthorId = 2 }
        }
        };

        _mockBookRepository.Setup(r => r.GetByIdAsync(book.Isbn))
                           .ReturnsAsync(book);

        // Act
        var result = await _bookService.GetBookByIdAsync(book.Isbn);

        // Assert
        _mockBookRepository.Verify(r => r.GetByIdAsync(book.Isbn), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(book.Isbn, result.Isbn);
        Assert.Equal(book.EditorialId, result.EditorialId);
        Assert.Equal(book.Synopsis, result.Synopsis);
        Assert.Equal(book.NPages, result.NPages);
        Assert.Equal(book.BookAuthors.Count, result.BookAuthors.Count());
        Assert.Equal(book.BookAuthors.First().AuthorId, result.BookAuthors.First().AuthorId);
        Assert.Equal(book.BookAuthors.Last().AuthorId, result.BookAuthors.Last().AuthorId);
    }

}
