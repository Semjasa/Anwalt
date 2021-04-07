// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using System.Text;
using Anwalt.Web.Data;
using Anwalt.Web.Data.Models;
using Anwalt.Web.Features.About.Abstractions;
using Anwalt.Web.Features.About.Services;
using Anwalt.Web.Features.Activity.Abstractions;
using Anwalt.Web.Features.Activity.Services;
using Anwalt.Web.Features.Employee.Abstractions;
using Anwalt.Web.Features.Employee.Services;
using Anwalt.Web.Features.Home.Abstractions;
using Anwalt.Web.Features.Home.Services;
using Anwalt.Web.Features.Identity.Abstractions;
using Anwalt.Web.Features.Identity.Services;
using Anwalt.Web.Infrastructure.Filters;
using Anwalt.Web.Infrastructure.Models;
using Anwalt.Web.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Anwalt.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static ApplicationSettings GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection("ApplicationSettings");

            services.Configure<ApplicationSettings>(applicationSettingsConfiguration);

            return applicationSettingsConfiguration.Get<ApplicationSettings>();
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IHomeService, HomeService>()
                .AddTransient<IAboutService, AboutService>()
                .AddTransient<IActivityService, ActivityService>()
                .AddTransient<IEmployeeService, EmployeeService>()
                .AddScoped<ICurrentUserService, CurrentUserService>();

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<AnwaltDbContext>(options =>
                    options.UseSqlServer(configuration.GetDefaultConnectionString()));

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<AnwaltDbContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection service,
            ApplicationSettings applicationSettings)
        {
            var key = Encoding.ASCII.GetBytes(applicationSettings.Secret);

            service.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return service;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services) =>
            services
                .AddSwaggerGen(s =>
                {
                    s.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Anwalt API",
                        Version = "v1"
                    });
                });

        public static IMvcBuilder AddApiControllers(this IServiceCollection services) =>
            services
                .AddControllers(options =>
                    options
                        .Filters
                        .Add<ModelOrNotFoundActionFilter>());
    }
}