using FruitSA.Persistence.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.IRepositories;
using ToDoList.Domain.IServices;
using ToDoList.Persistence.Connections;
using ToDoList.Persistence.Contexts;
using ToDoList.Persistence.Repositories;

namespace ToDoList.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDoList.API", Version = "v1" });
            });
            services.AddApiVersioning();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("todo-list");
            });
            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
            services.AddScoped<IAppWriteDbConnection, AppWriteDbConnection>();
            services.AddScoped<IAppReadDbConnection, AppReadDbConnection>();

            services.AddScoped<IToDoListItemRepository, ToDoListItemRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IToDoListItemService, ToDoListItemService>();

            services.AddAutoMapper(typeof(Startup));

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoList.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
