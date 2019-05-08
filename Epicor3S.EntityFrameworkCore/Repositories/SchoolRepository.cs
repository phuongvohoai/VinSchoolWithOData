using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Epicor3S.EntityFrameworkCore.Database;
using Epicor3S.Core.Models;
using Epicor3S.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Epicor3S.EntityFrameworkCore.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly Epicor3SDbContext _dbContext;

        public SchoolRepository(Epicor3SDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(School schoolDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<School> GetSchoolByIdAsync(string id)
        {
            return await _dbContext.Schools.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<School>> GetSchoolsAsync()
        {
            return await _dbContext.Schools.AsNoTracking().ToListAsync();
        }
    }
}
