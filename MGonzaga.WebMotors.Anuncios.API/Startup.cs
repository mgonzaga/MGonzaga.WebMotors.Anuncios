using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGonzaga.WebMotors.Anuncios.API.Middlewares;
using MGonzaga.WebMotors.Anuncios.Domain.Interfaces.Repositories;
using MGonzaga.WebMotors.Anuncios.Infrastructure.Context;
using MGonzaga.WebMotors.Anuncios.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace MGonzaga.WebMotors.Anuncios.API
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
            services.AddScoped(typeof(IDbContext), typeof(TesteWebMotorsContext));
            services.AddScoped(typeof(IAnuncioRepository), typeof(AnuncioRepository));
            services.AddControllers();
            services.AddDbContext<TesteWebMotorsContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionString"], opt =>
                {
                    opt.CommandTimeout(30);
                });
            });
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Teste-WebMotors", Version = "v1" });
            });
            services.AddMvcCore()
                .AddApiExplorer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware(typeof(ErrorsMiddleware));
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
