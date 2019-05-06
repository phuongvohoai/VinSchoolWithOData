using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Epicor3S.Core.Dtos;
using Epicor3S.Core.Services;
using Epicor3S.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Epicor3S.EntityFrameworkCore.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly Epicor3SDbContext _dbContext;
        private readonly IMapper _mapper;

        public SchoolService(Epicor3SDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task CreateAsync(SchoolDto schoolDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<SchoolDto> GetSchoolByIdAsync(string id)
        {
            var school = await _dbContext.Schools.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
            return _mapper.Map<SchoolDto>(school);
        }

        public async Task<IEnumerable<SchoolDto>> GetSchoolsAsync()
        {
            var schools = await _dbContext.Schools.AsNoTracking().ToListAsync();
            return _mapper.Map<IList<SchoolDto>>(schools);
        }
    }
}
