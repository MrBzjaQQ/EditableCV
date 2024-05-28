using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace EditableCV.Server.Authentication;

public sealed class ApiKeyAuthenticationSchemeHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
{
    public ApiKeyAuthenticationSchemeHandler(IOptionsMonitor<ApiKeyAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder) : base(options, logger, encoder)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var apiKey = Context.Request.Headers[AuthenticationConstants.ApiKeyHeader];
        if (apiKey != OptionsMonitor.CurrentValue.ApiKey)
        {
            return Task.FromResult(AuthenticateResult.Fail(AuthenticationConstants.Unauthorized));
        }

        var claims = new[] { new Claim(ClaimTypes.Name, "VALID USER") };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}
