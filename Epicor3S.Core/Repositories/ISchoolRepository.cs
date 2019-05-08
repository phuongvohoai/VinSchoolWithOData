using System.Collections.Generic;
using System.Threading.Tasks;
using Epicor3S.Core.Models;

namespace Epicor3S.Core.Repositories
{
    public interface ISchoolRepository
    {
        Task<IEnumerable<School>> GetSchoolsAsync();

        Task<School> GetSchoolByIdAsync(string id);

        Task CreateAsync(School schoolDto);
    }
}
