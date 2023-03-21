using Domain.Entities;
using Domain.Interfaces;
using Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EditorialService : IEditorialService
{
    private readonly IEditorialRepository _editorialRepository;

    public EditorialService(IEditorialRepository editorialRepository)
    {
        _editorialRepository = editorialRepository;
    }

    public async Task<IEnumerable<Editorial>> GetEditorialsAsync()
    {
        return await _editorialRepository.GetAllAsync();
    }

    public async Task<Editorial> GetEditorialByIdAsync(int id)
    {
        return await _editorialRepository.GetByIdAsync(id);
    }

    public async Task<Editorial> CreateEditorialAsync(Editorial editorial)
    {
        return await _editorialRepository.AddAsync(editorial);
    }

    public async Task<Editorial> UpdateEditorialAsync(Editorial editorial)
    {
        return await _editorialRepository.UpdateAsync(editorial);
    }

    public async Task<bool> DeleteEditorialAsync(int id)
    {
        return await _editorialRepository.DeleteAsync(id);
    }
}