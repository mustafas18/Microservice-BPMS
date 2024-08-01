using Azure.Core;
using Microsoft.AspNetCore.Authentication;

namespace Bpms.API.Infrastructure.Services;

public class IdentityService(IHttpContextAccessor context) : IIdentityService
{
    public string GetUserIdentity()
        => context.HttpContext?.User.FindFirst("sub")?.Value;

    public string GetUserName()
        => context.HttpContext?.User.Identity?.Name;
    public string? GetAccesssToken()
       => context.HttpContext?.Request.Headers["Authorization"];
}
