using Application.Interfaces;
using Domain.Entities;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthors()
    {
        var authors = await _authorService.GetAuthorsAsync();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthorById(int id)
    {
        var author = await _authorService.GetAuthorByIdAsync(id);
        if (author == null) return NotFound();

        return Ok(author);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor(AuthorDTO authorDTO)
    {
        var author = new Author();
        author.Name = authorDTO.Name;
        author.LastName = authorDTO.LastName;
        var createdAuthor = await _authorService.CreateAuthorAsync(author);
        return CreatedAtAction(nameof(GetAuthorById), new { id = createdAuthor.Id }, createdAuthor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthor(int id, Author author)
    {
        if (id != author.Id) return BadRequest();

        var updatedAuthor = await _authorService.UpdateAuthorAsync(author);
        if (updatedAuthor == null) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var result = await _authorService.DeleteAuthorAsync(id);
        if (!result) return NotFound();

        return NoContent();
    }
}
