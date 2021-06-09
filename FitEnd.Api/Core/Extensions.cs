using FitEnd.Application.Actors;
using FitEnd.Application.Commands;
using FitEnd.Application.Commands.ExerciseTypeCommands;
using FitEnd.Application.Commands.UserPlanCommands;
using FitEnd.Application.Commands.UsersCommand;
using FitEnd.Application.GenericActions;
using FitEnd.Application.Queries;
using FitEnd.Application.Queries.ExerciseQueries;
using FitEnd.Application.Queries.UserPlanQueries;
using FitEnd.Application.Queries.UserQueries;
using FitEnd.DataAccess;
using FitEnd.Implementation.Commands;
using FitEnd.Implementation.Commands.ExerciseTypeCommands;
using FitEnd.Implementation.Commands.UserCommands;
using FitEnd.Implementation.Commands.UserPlansCommands;
using FitEnd.Implementation.GenericActions;
using FitEnd.Implementation.Queries;
using FitEnd.Implementation.Queries.ExerciseQueries;
using FitEnd.Implementation.Queries.UserPlanQueries;
using FitEnd.Implementation.Queries.UserQueries;
using FitEnd.Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitEnd.Api.Core
{
    public static class Extensions
    {
        public static void DodavanjeUseCase(this IServiceCollection services)
        {
            services.AddTransient<IPregledVezba, UzmiVezbePaginacijom>();
            services.AddTransient<IPregledVezbePoID, UzmiVezbuPrekoID>();
            services.AddTransient<IUpisExercise, UpisExercise>();
            services.AddTransient<IUpdateExercise, UpdateExercise>();
            services.AddTransient<IRemoveExercise, RemoveExercise>();
            services.AddTransient<IPregledTipova, PregledTipova>();
            services.AddTransient<INewExerciseType, NewExerciseType>();
            services.AddTransient<IUpdateExerciseType, UpdateExerciseType>();
            services.AddTransient<IDeleteExerciseType, DeleteExerciseType>();
            services.AddTransient<IRegisterUser, RegisterUser>();
            services.AddTransient<ICreateNewUserPlan, CreateNewUserPlan>();
            services.AddTransient<IShowUserPlans, ShowUserPlans>();
            services.AddTransient<IDeleteUserPlan, DeleteUserPlan>();
            services.AddTransient<IPretragaPoNazivu, PretragaPoNazivu>();
            services.AddTransient<INewUserWeight, NewUserWeight>();
            services.AddTransient<IUserQuery, UserQuery>();
            services.AddTransient<IChangeUserRole,ChangeUserRole>();
            services.AddTransient<IRolesQuery, RolesQuery>();
            services.AddTransient<IDeleteUser, DeleteUser>();
            services.AddTransient<ICitanjeIzLogFajla, CitanjeLogFajla>();
             
             
             
            services.AddTransient<ExerciseValidator>();
            services.AddTransient<NewExerciseTypeValidator>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<NewUserPlanValidator>();
            services.AddTransient<NewUserWeightValidator>();
            services.AddTransient<ChangeUserRoleValidator>();
        }

        public static void dodavanjeJWT(this IServiceCollection services)
        {
          
            services.AddTransient<JwtAction>(x =>
            {
                var context = x.GetService<Context>();
                var enkoder = x.GetService<IEncodePassword>();
                return new JwtAction(context,enkoder);
            });

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
                    ValidIssuer = Config.JWTIssuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config.TajniJWTKljuc)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void DodavanjeAktora(this IServiceCollection services)
        {
            services.AddTransient<IAppActor>(x =>
            {
                var user = x.GetService<IHttpContextAccessor>().HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonimActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });
        }


        public static void DodavanjeSwaggera(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FitEnd", Version = "v1" });
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

    }
}
