using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VinSchool.Api.Models;

namespace VinSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly VinSchoolDbContext _dbContext;

        public StudentsController(VinSchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _dbContext.Students.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(string id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return student;

        }
    }
}
