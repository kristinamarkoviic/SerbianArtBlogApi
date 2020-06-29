using Arts.Application;
using Arts.Application.Commands;
using Arts.Application.Commands.Categories;
using Arts.Application.Commands.Comments;
using Arts.Application.Commands.Likes;
using Arts.Application.Commands.PieceOfArts;
using Arts.Application.Queries;
using Arts.Application.Queries.Categories;
using Arts.Application.Queries.PieceOfArts;
using Arts.Application.Queries.Users;
using Arts.DataAccess;
using Arts.Implementation.Commands;
using Arts.Implementation.Commands.Categories;
using Arts.Implementation.Commands.Comments;
using Arts.Implementation.Commands.Countries;
using Arts.Implementation.Commands.Likes;
using Arts.Implementation.Commands.PieceOfArts;
using Arts.Implementation.Commands.Users;
using Arts.Implementation.Queries;
using Arts.Implementation.Queries.Categories;
using Arts.Implementation.Queries.PieceOfArts;
using Arts.Implementation.Queries.Users;
using Arts.Implementation.Validators;
using Arts.Implementation.Validators.Categories;
using Arts.Implementation.Validators.Comments;
using Arts.Implementation.Validators.Countries;
using Arts.Implementation.Validators.PieceOfArts;
using Arts.Implementation.Validators.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arts.Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            //Commands
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<ICreateCountryCommand, EfCreateCountryCommand>();
            services.AddTransient<ICreateUserUseCaseCommand, EfCreateUserUseCasesCommand>();
            services.AddTransient<IDeleteUserUseCaseCommand, EfDeleteUserUseCaseCommand>();
            services.AddTransient<IDeleteCountryCommand, EfDeleteCountriesCommand>();
            services.AddTransient<IUpdateCountryCommand, EfUpdateCountryCommand>();
            services.AddTransient<IUpdateUserUseCaseCommand, EfUpdateUserUseCaseCommand>();
            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<ICreatePieceOfArtCommand, EfCreatePieceOfArtCommand>();
            services.AddTransient<IUpdatePieceOfArtCommand, EfUpdatePieceOfArtCommand>();
            services.AddTransient<IDeletePieceOfArtCommand, EfDeletePieceOfArtCommand>();
            services.AddTransient<IUpdatePersonalPieceOfArtCommand, EfUpdatePersonalPieceOfArtCommand>();
            services.AddTransient<IDeletePersonalPieceOfArtCommand, EfDeletePersonalPieceOfArtCommand>();
            services.AddTransient<ICreateCommentCommand, EfCreateCommentCommand>();
            services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();
            services.AddTransient<IDeletePersonalCommentCommand, EfDeletePersonalCommentCommand>();
            services.AddTransient<IUpdateCommentCommand, EfUpdateCommentCommand>();
            services.AddTransient<ILikePostCommand, EfLikePostCommand>();


            //Queries
            services.AddTransient<IGetCountriesQuery, EfGetCountriesQuery>();
            services.AddTransient<IGetUseCaseLogsQuery, EfGetUseCaseLogsQuery>();
            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<IGetOneUserClientQuery, EfGetSingleUserClientQuery>();
            services.AddTransient<IGetOneUserQuery, EfGetOneUserQuery>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetUsersClientQuery, EfGetUsersClientQuery>();
            services.AddTransient<IGetPieceOfArtQuery, EfGetPieceOfArtsQuery>();
            services.AddTransient<IGetOnePieceOfArtQuery, EfGetOnePieceOfArtQuery>();
            services.AddTransient<IGetOneCategoryQuery, EfGetOneCategoryQuery>();

            //Validators
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<CreateCountryValidator>();
            services.AddTransient<DeleteCountryValidator>();
            services.AddTransient<CreateUserUseCaseValidator>();
            services.AddTransient<UpdateCountryValidator>();
            services.AddTransient<UpdateUserUseCaseValidator>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<DeleteCategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<CreatePieceOfArtValidator>();
            services.AddTransient<DeletePieceOfArtValidator>();
            services.AddTransient<CreateCommentValidator>();
            services.AddTransient<UpdateCommentValidator>();
            services.AddTransient<DeleteCommentValidator>();
            services.AddTransient<LikeValidator>();

        }

        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();


                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnnonymusActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });

        }

        public static void AddJwt(this IServiceCollection services)
        {
            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<ArtsContext>();

                return new JwtManager(context);
            });

            //jwt token setup
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
