using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
using OnlineShopWebAPI.API.Mapping;
using OnlineShopWebAPI.Core;
using OnlineShopWebAPI.Core.Repositories;
using OnlineShopWebAPI.Data;
using OnlineShopWebAPI.Services;

namespace OnlineShopWebAPI.API
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDbContext<OnlineShopDbContext>(options => options
            .UseSqlServer(connection), ServiceLifetime.Scoped);
          
            services.AddControllers();
            services.AddScoped <IUnitOfWork, UnitOfWork>();

            services.AddTransient<IProductService, ProductService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1",
                  new OpenApiInfo
                  {
                      Title = "Swagger",
                      Version = "v1"
                  });
            });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Online Shop V1");
            });
        }
    }
}
