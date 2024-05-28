using Microsoft.AspNetCore.Authentication;

namespace EditableCV.Server.Authentication;

public sealed class ApiKeyAuthenticationOptions: AuthenticationSchemeOptions
{
    public string ApiKey { get; init; } = string.Empty;
}
