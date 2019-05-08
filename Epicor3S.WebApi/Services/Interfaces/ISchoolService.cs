using System.Collections.Generic;
using System.Threading.Tasks;
using Epicor3S.WebApi.Dtos;

namespace Epicor3S.WebApi.Services.Interfaces
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolDto>> GetSchoolsAsync();

        Task<SchoolDto> GetSchoolByIdAsync(string id);

        Task CreateAsync(SchoolDto schoolDto);
    }
}
