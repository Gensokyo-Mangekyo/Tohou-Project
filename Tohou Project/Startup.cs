using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tohou_Project.Models;

namespace Tohou_Project
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration cfg)
        {
            Configuration = cfg;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<PathRepository>();
            
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<InfoMangaContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            env.EnvironmentName = "Testing";
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
