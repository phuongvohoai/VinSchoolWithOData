using AutoMapper;
using Epicor3S.Core.Dtos;
using Epicor3S.Core.Models;

namespace Epicor3S.Core.MapperProfiles
{
    public class Epicor3SProfile : Profile
    {
        public Epicor3SProfile()
        {
            CreateMap<School, SchoolDto>();
            CreateMap<SchoolDto, School>();
        }
    }
}
