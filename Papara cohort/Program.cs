using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Papara_cohort.Authentication;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Papara_cohort.Model;


namespace Papara_cohort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
            builder.Services.AddLogging();

            // Dependency Injection
            builder.Services.AddScoped<IAuthService, UserAuthService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            // FluentValidation için baðýmlýlýk ekleme
            builder.Services.AddTransient<IValidator<Author>, AuthorValidator>();
            builder.Services.AddTransient<IValidator<Book>, BookValidator>();
            builder.Services.AddTransient<IValidator<Genre>, GenreValidator>();

            // Authentication middleware
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "BasicAuthentication";
                options.DefaultChallengeScheme = "BasicAuthentication";
            })
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", options => { });

            // Authorization policy
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("SecurePolicy", policy =>
                {
                    policy.RequireAuthenticatedUser();
                });
            });

            // Swagger API documentation
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Papara_cohort", Version = "v1" });
                c.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    Description = "Input your username and password to access this API"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Basic"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            // Automapper configuration
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Papara_cohort v1");
            });

            app.Run();
        }
    }
}
