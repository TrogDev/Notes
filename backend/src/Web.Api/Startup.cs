using Notes.Infrastructure.Identity;
using Notes.Web.Api.Common.Configurations;

namespace Notes.Web.Api;

internal class Startup
{
    private readonly IConfiguration configuration;

    public Startup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddApplicationServices(configuration);
        services.AddInfrastructureServices(configuration);
        services.AddWebServices(configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        app.ConfigureDatabase();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapIdentityApi<ApplicationUser>();
        });
    }
}
