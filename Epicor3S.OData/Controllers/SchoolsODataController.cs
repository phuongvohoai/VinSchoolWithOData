using System.Linq;
using Epicor3S.EntityFrameworkCore.Database;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace Epicor3S.OData.Controllers
{
    public class SchoolsODataController : ODataController
    {
        private readonly Epicor3SDbContext _dbContext;

        public SchoolsODataController(Epicor3SDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [EnableQuery()]
        public IActionResult GetSchools()
        {
            return Ok(_dbContext.Schools.AsQueryable());
        }

        [EnableQuery()]
        public IActionResult GetById(string id)
        {
            return Ok(_dbContext.Schools.Find(id));
        }
    }
}
