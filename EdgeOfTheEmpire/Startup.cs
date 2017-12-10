using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using EdgeOfTheEmpire.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using EdgeOfTheEmpire.Services;

namespace EdgeOfTheEmpire
{
    public class Startup
    {
        private IConfigurationRoot configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IStaticDataRepository, StaticDataRepository>();
            services.AddTransient<ICharacterRepository, CharacterRepository>();
            services.AddDbContext<CharacterDbContext>(options =>
                        options.UseSqlServer(configurationRoot.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Career}/{action=List}/{id?}");
            });
        }
    }
}
