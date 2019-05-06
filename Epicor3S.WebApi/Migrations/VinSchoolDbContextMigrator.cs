using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epicor3S.Core.Models;
using Epicor3S.EntityFrameworkCore.Repositories;

namespace Epicor3S.WebApi.Migrations
{
    public static class VinSchoolDbContextMigrator
    {
        public static async Task Migrate(Epicor3SDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Schools.Count() == 0)
            {
                await dbContext.Schools.AddRangeAsync(GetDummySchools());
                await dbContext.SaveChangesAsync();
            }
        }

        private static IList<School> GetDummySchools()
        {
            return new List<School>
            {
                new School
                {
                    Name = "School Test",
                    Website = "http://schooltest.com"
                },
                new School
                {
                     Name = "Groo Education",
                    Website = "http://groo-education.com"
                }
            };
        }
    }
}