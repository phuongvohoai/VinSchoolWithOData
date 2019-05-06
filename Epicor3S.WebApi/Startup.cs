using AutoMapper;
using Epicor3S.Core.MapperProfiles;
using Epicor3S.Core.Services;
using Epicor3S.EntityFrameworkCore.Repositories;
using Epicor3S.EntityFrameworkCore.Services;
using Epicor3S.OData;
using Epicor3S.WebApi.Constant;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Epicor3S.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Register auto mapper
            services.AddAutoMapper(typeof(Epicor3SProfile).Assembly);

            // Register db context
            services.AddDbContext<Epicor3SDbContext>(opt => opt.UseInMemoryDatabase("VinSchool"));

            // Register mvc
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Register services layer
            services.AddScoped<ISchoolService, SchoolService>();

            // Register http client
            services.AddHttpClient(HttpClientNames.CodeOrgClient, c =>
            {
                c.BaseAddress = new System.Uri("https://code.org/");
            });

            // Register Odata
            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(b =>
            {
                b.MapODataServiceRoute("odata", "odata", EdmModelBuilder.GetEdmModel());
            });
        }
    }
}
