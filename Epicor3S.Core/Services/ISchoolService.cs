using System.Collections.Generic;
using System.Threading.Tasks;
using Epicor3S.Core.Dtos;

namespace Epicor3S.Core.Services
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolDto>> GetSchoolsAsync();

        Task<SchoolDto> GetSchoolByIdAsync(string id);

        Task CreateAsync(SchoolDto schoolDto);
    }
}
