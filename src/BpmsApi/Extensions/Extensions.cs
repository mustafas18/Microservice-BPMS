using Bpms.Services.Identity;
using Bpms.ServiceDefaults;
using System.Security.Principal;
using BPMS.Infrastructure;
using BPMSDomain.Interfaces;
using BPMS.Infrastructure.Services;

namespace BpmsApi.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {

            builder.AddDefaultAuthentication();

            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddScoped<NodeBranchService>();
            builder.Services.AddSingleton<IIdentityService, IdentityService>();

            builder.Services.AddHttpContextAccessor();
        }
    }

}