using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Application.Interfaces
{
    public interface IEditorialService
    {
        Task<IEnumerable<Editorial>> GetEditorialsAsync();
        Task<Editorial> GetEditorialByIdAsync(int id);
        Task<Editorial> CreateEditorialAsync(Editorial editorial);
        Task<Editorial> UpdateEditorialAsync(Editorial editorial);
        Task<bool> DeleteEditorialAsync(int id);
    }
}
