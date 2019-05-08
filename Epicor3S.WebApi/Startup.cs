using AutoMapper;
using Epicor3S.Core.MapperProfiles;
using Epicor3S.Core.Repositories;
using Epicor3S.EntityFrameworkCore.Database;
using Epicor3S.EntityFrameworkCore.Repositories;
using Epicor3S.OData;
using Epicor3S.WebApi.Constant;
using Epicor3S.WebApi.Services;
using Epicor3S.WebApi.Services.Interfaces;
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

            // Register services layer
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<ISchoolService, SchoolService>();

            // Register http client
            services.AddHttpClient(HttpClientNames.CodeOrgClient, c =>
            {
                c.BaseAddress = new System.Uri("https://code.org/");
            });

            // Register Odata
            services.AddOData();
            services.AddODataQueryFilter();
            services.AddTransient<EdmModelBuilder>();

            // Register mvc
            services.AddMvc(mvcOptions =>
            {
                // https://blogs.msdn.microsoft.com/webdev/2018/08/27/asp-net-core-2-2-0-preview1-endpoint-routing/
                mvcOptions.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, EdmModelBuilder edmModelBuilder)
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
            app.UseMvc(routeBuilder =>
            {
                // Build OData on existing api
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Expand().Select().Count().OrderBy();

                // Build OData with edm model
                //routeBuilder.MapODataServiceRoute("odata", "odata", edmModelBuilder.GetEdmModel());
            });
        }
    }
}
