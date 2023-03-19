using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BrowserTravelTest.Models;

public partial class BrowserTravelTestDbContext : DbContext
{
    public BrowserTravelTestDbContext()
    {
    }

    public BrowserTravelTestDbContext(DbContextOptions<BrowserTravelTestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Editorial> Editorials { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=localhost; database=BrowserTravelTestDB; integrated security=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__authors__3213E83F6F4E9B95");

            entity.ToTable("authors");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Lastname)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasMany(d => d.BookIsbns).WithMany(p => p.Authors)
                .UsingEntity<Dictionary<string, object>>(
                    "AuthorBook",
                    r => r.HasOne<Book>().WithMany()
                        .HasForeignKey("BookIsbn")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__author_bo__book___3F466844"),
                    l => l.HasOne<Author>().WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__author_bo__autho__3E52440B"),
                    j =>
                    {
                        j.HasKey("AuthorId", "BookIsbn").HasName("PK__author_b__20E69C9F683304C5");
                        j.ToTable("author_book");
                        j.IndexerProperty<int>("AuthorId").HasColumnName("author_id");
                        j.IndexerProperty<long>("BookIsbn").HasColumnName("book_ISBN");
                    });
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("PK__books__447D36EB474F2942");

            entity.ToTable("books");

            entity.Property(e => e.Isbn)
                .ValueGeneratedNever()
                .HasColumnName("ISBN");
            entity.Property(e => e.EditorialId).HasColumnName("editorial_id");
            entity.Property(e => e.NPages)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("n_pages");
            entity.Property(e => e.Synopsis)
                .HasColumnType("text")
                .HasColumnName("synopsis");

            entity.HasOne(d => d.Editorial).WithMany(p => p.Books)
                .HasForeignKey(d => d.EditorialId)
                .HasConstraintName("FK__books__editorial__3B75D760");
        });

        modelBuilder.Entity<Editorial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__editoria__3213E83F0590062B");

            entity.ToTable("editorials");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Campus)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("campus");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
