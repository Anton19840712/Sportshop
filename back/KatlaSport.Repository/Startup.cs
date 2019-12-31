using KatlaSport.Repository.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KatlaSport.Repository
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("SportNutritionDBConnetction")));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //services.AddSingleton<ISportNutritionClientRepository, MockSportNutritionClientRepository>();
            services.AddMvc().AddXmlDataContractSerializerFormatters();
            services.AddScoped<ISportNutritionClientRepository, SQLSportNutritionClientRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.Use(async (context, next) =>
            {
                //await context.Response.WriteAsync("Hello from 1st Middleware!");
                logger.LogInformation("Incoming request1");
                await next();
                logger.LogInformation("Outgoing response1");
            });

            app.Use(async (context, next) =>
            {
                //await context.Response.WriteAsync("Hello from 1st Middleware!");
                logger.LogInformation("Incoming request2");
                await next();
                logger.LogInformation("Outgoing response2");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MW3 Request handled and responce produced");
                logger.LogInformation("MW3 Request handled and responce produced");
            });

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
