using Bpms.ServiceDefaults;
using BpmsVariables.Infrastructure;
using System.Security.Principal;

namespace Variables.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {

            builder.AddDefaultAuthentication();

            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));


            builder.Services.AddHttpContextAccessor();
        }
    }

}