using Bpms.API.Infrastructure.Services;
using BpmsApi.Services;
using eShop.ServiceDefaults;
using System.Security.Principal;

namespace BpmsApi.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {

            builder.AddDefaultAuthentication();

            builder.Services.AddSingleton<IWeatherForcast, WeatherForcast>();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<IIdentityService, IdentityService>();
        }
    }

}