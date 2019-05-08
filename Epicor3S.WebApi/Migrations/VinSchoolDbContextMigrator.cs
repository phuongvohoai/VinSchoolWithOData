using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Epicor3S.Core.Models;
using Epicor3S.EntityFrameworkCore.Database;
using Epicor3S.WebApi.Constant;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Epicor3S.WebApi.Migrations
{
    public static class VinSchoolDbContextMigrator
    {
        public static async Task Migrate(Epicor3SDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Schools.Count() == 0)
            {
                await dbContext.Schools.AddRangeAsync(await GetSchoolsAsync(serviceProvider));
                await dbContext.SaveChangesAsync();
            }
        }

        private static async Task<IList<School>> GetSchoolsAsync(IServiceProvider serviceProvider)
        {

            var schools = new List<School>();
            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient(HttpClientNames.CodeOrgClient);
            var apiResponse = await httpClient.GetAsync("schools.json");
            dynamic jsonData = JsonConvert.DeserializeObject<dynamic>(await apiResponse.Content.ReadAsStringAsync());

            foreach (var school in jsonData.schools)
            {
                schools.Add(new School
                {
                    Name = school.name,
                    Website = school.website
                });
            }

            return schools;


        }
    }
}