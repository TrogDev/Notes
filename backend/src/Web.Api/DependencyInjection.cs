namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Configuration;

using Notes.Application.Common.Interfaces;
using Notes.Web.Api.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddScoped<ICurrentUser, CurrentUser>();
        return services;
    }
}
