using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicStock.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ComicStock
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
            this.ConfigureCorsService(services);
            this.ConfigureDbContextService(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        private void ConfigureCorsService(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                //TODO: move to appsettings
                var allowedOrigins = new[]
                {
                    "https://comicstore.azurewebsites.net",
                    "http://localhost:3000",
                    "http://localhost:5000"
                };

                options.AddPolicy(
                    "AllowSpecificOrigin",
                    builder => builder.WithOrigins(allowedOrigins));
            });
        }

        private void ConfigureDbContextService(IServiceCollection services)
        {
            var connection = "Data Source=comicstore.db";

            services.AddDbContext<ComicStockContext>(opt =>
                opt.UseSqlite(connection));
            
            // var connection = Configuration.GetConnectionString("comicstock");

            // services.AddDbContext<ComicStockContext>(opt =>
            //     opt.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            UpdateDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // else
            // {
            //     app.UseHsts();
            // }
            app.UseCors("AllowSpecificOrigin");
            //app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ComicStockContext>())
                {
                    context.Database.EnsureCreated();
                }
            }
        }
    }
}
