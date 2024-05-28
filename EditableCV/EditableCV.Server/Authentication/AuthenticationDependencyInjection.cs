using Microsoft.Extensions.DependencyInjection;

namespace EditableCV.Server.Authentication;

public static class AuthenticationDependencyInjection
{
    public static IServiceCollection AddAuthenticationHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<ApiKeyAuthenticationOptions>().Bind(configuration.GetSection(AuthenticationConstants.OptionsKey));
        services.AddAuthentication(cfg =>
        {
            cfg.AddScheme<ApiKeyAuthenticationSchemeHandler>(AuthenticationConstants.SchemeName, null);
            cfg.DefaultScheme = AuthenticationConstants.SchemeName;
        });

        return services;
    }
}
