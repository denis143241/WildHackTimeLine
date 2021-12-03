using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VueCliMiddleware;

// namespace WildHackWebApp
// {
//     public class Startup
//     {
//         public Startup(IConfiguration configuration)
//         {
//             Configuration = configuration;
//         }

//         public IConfiguration Configuration { get; }

//         // This method gets called by the runtime. Use this method to add services to the container.
//         public void ConfigureServices(IServiceCollection services)
//         {

//             services.AddControllers();
//             //services.AddSwaggerGen(c =>
//             //{
//             //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WildHackWebApp", Version = "v1" });
//             //});
//         }

//         // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//         {
//             if (env.IsDevelopment())
//             {
//                 app.UseDeveloperExceptionPage();
//                 //app.UseSwagger();
//                 //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WildHackWebApp v1"));
//             }

//             app.UseHttpsRedirection();

//             app.UseRouting();

//             app.UseAuthorization();

//             app.UseEndpoints(endpoints =>
//             {
//                 endpoints.MapControllers();
//             });
//         }
//     }
// }


// NEW STARTUP

namespace WildHackWebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSpaStaticFiles(opt => opt.RootPath = "client-app/dist");
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapToVueCliProxy(
                    "{*path}",
                    new SpaOptions { SourcePath = "client-app" },
                    npmScript: (System.Diagnostics.Debugger.IsAttached) ? "serve" : null,
                    regex: "Compiled successfully",
                    forceKill: true
                    );
            });
        }
    }
}
