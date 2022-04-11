using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Zoo_API
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

            // Adds database connection as scoped (only used once per request)
            services.AddScoped<IDbConnection>(s =>
            {
                IDbConnection conn = new
                MySqlConnection(Configuration.GetConnectionString("zoo"));
                conn.Open();
                return conn;
            });

            // Adds interface repo and repo as transients (created for each request)
            services.AddTransient<IZoo_AnimalsRepo, Zoo_AnimalsRepo>();

            // CORS = Cross Open Resource Sharing
            // Opens up the Api to not just limit the callers to a specific domain or individual URL, but any origin
            // to make our API more accessible
            services.AddCors(options =>     
            {                               
            options.AddPolicy("AllowOrigin", builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Zoo API", Version = "v1" });
            });
        }

        // -------------------------------------

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // allows the use of developer tools like swagger
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // redirects http requests to https requests
            app.UseHttpsRedirection();

            // This method is used to find the endpoint
            app.UseRouting();

            // This is added in order to open up CORS
            app.UseCors("AllowedOrigin");

            app.UseAuthorization();

            // This method executes the endpoint with the mapped controller action
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
