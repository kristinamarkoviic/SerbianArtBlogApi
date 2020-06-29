using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arts.Api.Core;
using Arts.Application;
using Arts.Application.Commands;
using Arts.Application.Email;
using Arts.Application.Queries;
using Arts.DataAccess;
using Arts.Implementation.Commands;
using Arts.Implementation.Commands.Categories;
using Arts.Implementation.Commands.Comments;
using Arts.Implementation.Commands.Countries;
using Arts.Implementation.Commands.PieceOfArts;
using Arts.Implementation.Email;
using Arts.Implementation.Logging;
using Arts.Implementation.Queries;
using Arts.Implementation.Queries.Categories;
using Arts.Implementation.Queries.Users;
using Arts.Implementation.Validators;
using Arts.Implementation.Validators.Countries;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Arts.Api
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
            
            services.AddTransient<ArtsContext>();


            services.AddApplicationActor();
            services.AddJwt();
            services.AddUseCases();


            //Usecase logger and executor
            services.AddTransient<IUseCaseLogger, UseCaseLogger>();
            services.AddTransient<IUseCaseExecutor>();

            //Services
            services.AddTransient<JwtManager>();
            services.AddTransient<IEmailSender, SmtpEmailSender>();
            //services.AddAutoMapper(this.GetType().Assembly);

            services.AddHttpContextAccessor();

            //Add automapper
            services.AddAutoMapper(typeof(EfGetUseCaseLogsQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetCountriesQuery).Assembly);
            services.AddAutoMapper(typeof(EfCreateCountryCommand).Assembly);
            services.AddAutoMapper(typeof(EfUpdateCountryCommand).Assembly);
            services.AddAutoMapper(typeof(EfCreateUserUseCasesCommand).Assembly);
            //services.AddAutoMapper(typeof(EfUpdateUserUseCaseCommand).Assembly);
            services.AddAutoMapper(typeof(EfRegisterUserCommand).Assembly);
            services.AddAutoMapper(typeof(EfCreateCategoryCommand).Assembly);
            services.AddAutoMapper(typeof(EfGetOneUserQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetSingleUserClientQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetUsersClientQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetUsersQuery).Assembly);
            services.AddAutoMapper(typeof(EfCreatePieceOfArtCommand).Assembly);
            services.AddAutoMapper(typeof(EfGetOneCategoryQuery).Assembly);
            services.AddAutoMapper(typeof(EfCreateCommentCommand));
            services.AddControllers();

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Serbian Arts Application", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                          {
                            Reference = new OpenApiReference
                              {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,

                            },
                            new List<string>()
                          }
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });

            app.UseRouting();

            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
