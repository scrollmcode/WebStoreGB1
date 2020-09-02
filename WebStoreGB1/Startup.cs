using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebStoreGB1.Infrastructure;
using WebStoreGB1.Infrastructure.Interfaces;
using WebStoreGB1.Infrastructure.Services;

namespace WebStoreGB1
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Добавляем разрешение зависимости
            services.AddSingleton<IEmployeesService, InMemoryEmployeesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            var helloString = _configuration["CustomHelloWorld"];

            app.UseRouting();

            UseMiddlewareSample(app);

            app.UseMiddleware<TokenMiddleware>();

            app.Map("/CustomMethod", CustomIndexHandler);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });

            //app.UseWelcomePage();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Страница не обнаружена.");
            });
        }

        private void CustomIndexHandler(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("response to /CustomMethod URL...");
            });
        }

        private void UseMiddlewareSample(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                bool isError = false;
                isError = context.Request.Query["call_error"] == "call_error";
                // ...
                if (isError)
                {
                    await context.Response
                        .WriteAsync("Вызвана ошибка /n call_error!");
                }
                else
                {
                    await next.Invoke();
                }
            });
        }
    }
}
