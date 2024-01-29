namespace Notes.Web.Api.Common.Configurations;

using Notes.Infrastructure.Database;

public static class DatabaseConfiguration
{
    public static IApplicationBuilder ConfigureDatabase(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        var initialiser =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
        initialiser.Initialise();

        return app;
    }
}
