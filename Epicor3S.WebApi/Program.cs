using System.Threading.Tasks;
using Epicor3S.EntityFrameworkCore.Repositories;
using Epicor3S.WebApi.Common;
using Epicor3S.WebApi.Migrations;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Epicor3S.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();

            await webHost.MigrateDbContextAsync<Epicor3SDbContext>(VinSchoolDbContextMigrator.Migrate);

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
