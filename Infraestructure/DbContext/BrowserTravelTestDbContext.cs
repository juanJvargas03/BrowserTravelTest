using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class BrowserTravelTestDbContext : DbContext
{
    public BrowserTravelTestDbContext(DbContextOptions<BrowserTravelTestDbContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Editorial> Editorials { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(a => a.Id);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Isbn);
            entity.Property(e => e.EditorialId).HasColumnName("editorial_id");
            entity.Property(e => e.NPages).HasColumnName("n_pages");
            entity.HasOne(e => e.Editorial)
                  .WithMany(e => e.Books)
                  .HasForeignKey(e => e.EditorialId);
        });

        modelBuilder.Entity<Editorial>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<BookAuthor>()
        .ToTable("author_book")
        .HasKey(ba => new { ba.BookISBN, ba.AuthorId });

        modelBuilder.Entity<BookAuthor>()
            .ToTable("author_book")
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.BookISBN);

        modelBuilder.Entity<BookAuthor>()
            .ToTable("author_book")
            .HasOne(ba => ba.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(ba => ba.AuthorId);

        modelBuilder.Entity<BookAuthor>()
            .Property(ba => ba.AuthorId)
            .HasColumnName("author_id");

        modelBuilder.Entity<BookAuthor>()
            .Property(ba => ba.BookISBN)
            .HasColumnName("book_ISBN");
    }
}
