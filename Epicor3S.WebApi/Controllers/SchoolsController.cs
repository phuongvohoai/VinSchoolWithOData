using System.Collections.Generic;
using System.Threading.Tasks;
using Epicor3S.WebApi.Dtos;
using Epicor3S.WebApi.Services.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace Epicor3S.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolsController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<IEnumerable<SchoolDto>> GetSchools()
        {
            return await _schoolService.GetSchoolsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolDto>> GetById(string id)
        {
            var student = await _schoolService.GetSchoolByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return student;
        }
    }
}
