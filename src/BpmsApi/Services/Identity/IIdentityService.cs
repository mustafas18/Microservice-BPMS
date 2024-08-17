namespace Bpms.Services.Identity;

public interface IIdentityService
{
    string GetUserIdentity();

    string GetUserName();
    string? GetAccesssToken();
}

