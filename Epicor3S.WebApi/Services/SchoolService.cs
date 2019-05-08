using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Epicor3S.WebApi.Dtos;
using Epicor3S.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Epicor3S.WebApi.Services.Interfaces;
using Epicor3S.Core.Repositories;
using Epicor3S.Core.Models;

namespace Epicor3S.WebApi.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;

        public SchoolService(ISchoolRepository schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(SchoolDto schoolDto)
        {
            await _schoolRepository.CreateAsync(_mapper.Map<School>(schoolDto));
        }

        public async Task<SchoolDto> GetSchoolByIdAsync(string id)
        {
            var school = await _schoolRepository.GetSchoolByIdAsync(id);
            return _mapper.Map<SchoolDto>(school);
        }

        public async Task<IEnumerable<SchoolDto>> GetSchoolsAsync()
        {
            var schools = await _schoolRepository.GetSchoolsAsync();
            return _mapper.Map<IList<SchoolDto>>(schools);
        }
    }
}