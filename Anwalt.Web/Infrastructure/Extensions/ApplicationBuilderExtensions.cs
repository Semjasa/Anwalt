// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using System;
using Anwalt.Web.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Anwalt.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddDevelopmentExceptionPage(this IApplicationBuilder app) =>
            app
                .UseDeveloperExceptionPage();

        public static IApplicationBuilder AddCors(this IApplicationBuilder app) =>
            app.UseCors(options =>
                options
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin());

        public static IApplicationBuilder AddEndpoints(this IApplicationBuilder app) =>
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<AnwaltDbContext>();

            dbContext?.Database.Migrate();
        }

        public static IApplicationBuilder AddSwaggerUi(this IApplicationBuilder app) =>
            app
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Anwalt API");
                    options.RoutePrefix = string.Empty;
                });
    }
}