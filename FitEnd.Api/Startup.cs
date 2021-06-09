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
using FitEnd.DataAccess;
using FitEnd.Implementation.Queries;
using FitEnd.Application.Queries;
using FitEnd.Application;
using FitEnd.Api.Core;
using AutoMapper;
using FitEnd.Implementation.Validators;
using FitEnd.Application.Commands;
using FitEnd.Implementation.Commands;
using FitEnd.Implementation.GenericActions;
using FitEnd.Application.GenericActions;
using FitEnd.Application.Actors;
using FitEnd.Implementation.Loggers;
using FitEnd.Implementation.Email;
using FitEnd.Application.Email;

namespace FitEnd.Api
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
            services.AddHttpContextAccessor();
            services.AddDbContext<Context>();
            services.AddTransient<Executor>();
            services.AddTransient<IEmailSender>(x => new EmailSender(Config.EmailSend,Config.EmailPassword));
            services.DodavanjeAktora();
            services.dodavanjeJWT();
            services.AddTransient<Application.ILogger, TextFileLogger>();
            services.AddTransient<IPrebacivacSlika, PrebacivanjeSlika>();
            services.AddTransient<IEncodePassword, EncodePassword>();
            
            services.DodavanjeUseCase();
            services.AddControllers();

            services.DodavanjeSwaggera();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
              
            }

            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });

            app.UseMiddleware<GlobalExceptionHandler>();
            
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
