using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using VinSchool.Api.Common;
using VinSchool.Api.Models;

namespace VinSchool.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();

            await webHost.MigrateDbContextAsync<VinSchoolDbContext>(async (context, services) =>
            {
                if (!context.Schools.Any())
                {

                }

                if (!context.Students.Any())
                {

                }

            });

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
