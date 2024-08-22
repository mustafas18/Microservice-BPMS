using Bpms.Services.Identity;
using Bpms.ServiceDefaults;
using System.Security.Principal;

namespace BpmsApi.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {

            builder.AddDefaultAuthentication();

            builder.Services.AddSingleton<IIdentityService, IdentityService>();

            builder.Services.AddHttpContextAccessor();
        }
    }

}