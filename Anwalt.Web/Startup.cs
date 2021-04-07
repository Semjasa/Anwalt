using Anwalt.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Anwalt.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddDatabase(Configuration)
                .AddIdentity()
                .AddJwtAuthentication(services.GetApplicationSettings(Configuration))
                .AddApplicationServices()
                .AddSwagger()
                .AddApiControllers();

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) => 
            app
                .AddDevelopmentExceptionPage()
                .UseSwagger()
                .AddSwaggerUi()
                .UseRouting()
                .AddCors()
                .UseAuthentication()
                .UseAuthorization()
                .AddEndpoints()
                .ApplyMigrations();
    }
}
