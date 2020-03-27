using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using CleanArchitectureBoilerplate.Middleware;
using CleanArchitectureBoilerplate.DataAccess.Repositories.Interfaces;
using CleanArchitectureBoilerplate.DataAccess.Repositories;
using CleanArchitectureBoilerplate.Domain.Services.Interfaces;
using CleanArchitectureBoilerplate.Domain.Services;
using CleanArchitectureBoilerplate.Domain.Mappers;
using CleanArchitectureBoilerplate.Domain.Mappers.Interfaces;
using FluentValidation;
using CleanArchitectureBoilerplate.Models.Requests;
using CleanArchitectureBoilerplate.Domain.Validators;

namespace CleanArchitectureBoilerplate
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
            services.AddControllers().AddFluentValidation(fv => {
                //Makes Fluent Validation the only validation allowed.
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });

            //App dependencies
            services.AddTransient<IValidator<PersonCreateRequest>, PersonCreateValidator>();

            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonMapper, PersonMapper>();
            services.AddTransient<IPersonService, PersonService>();
            //services.AddTransient<ICompanyRepository, CompanyRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "API",
                    Description = "Clean Architecture Boilerplate API",
                    Contact = new OpenApiContact()
                    {
                        Name = "Carlos Jimenez",
                        Email = "cjimenezber@gmail.com"
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "MIT"
                    },
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

            if(env.IsDevelopment())
            {
                app.UseMiddleware(typeof(DevelopmentExceptionMiddleware));
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Clean Architecture Boilerplate API.");
                });
            }
            else
            {
                app.UseMiddleware(typeof(GlobalExceptionMiddleware));
            }
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
