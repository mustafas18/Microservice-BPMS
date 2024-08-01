using Bpms.API.Infrastructure.Services;
using BpmsApi.Services;
using System.Security.Principal;

namespace BpmsApi.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {


            builder.Services.AddSingleton<IWeatherForcast, WeatherForcast>();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<IIdentityService, IdentityService>();
        }
    }

}