using Application.Interfaces;
using Domain.Entities;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class EditorialsController : ControllerBase
{
    private readonly IEditorialService _editorialService;

    public EditorialsController(IEditorialService editorialService)
    {
        _editorialService = editorialService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEditorials()
    {
        var editorials = await _editorialService.GetEditorialsAsync();
        return Ok(editorials);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEditorialById(int id)
    {
        var editorial = await _editorialService.GetEditorialByIdAsync(id);
        if (editorial == null) return NotFound();

        return Ok(editorial);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEditorial(EditorialDTO editorialDTO)
    {
        Editorial editorial = new Editorial();
        editorial.Campus = editorialDTO.Campus;
        editorial.Name = editorialDTO.Name;
        var createdEditorial = await _editorialService.CreateEditorialAsync(editorial);
        return CreatedAtAction(nameof(GetEditorialById), new { id = createdEditorial.Id }, createdEditorial);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEditorial(int id, Editorial editorial)
    {
        if (id != editorial.Id) return BadRequest();

        var updatedEditorial = await _editorialService.UpdateEditorialAsync(editorial);
        if (updatedEditorial == null) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEditorial(int id)
    {
        var result = await _editorialService.DeleteEditorialAsync(id);
        if (!result) return NotFound();

        return NoContent();
    }
}
