using Bpms.ServiceDefaults;
using FormMakerApi;
using FormMakerApi.Infrastructure;
using FormMakerApi.Services;
using System.Security.Principal;

namespace FormMaker.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {

            builder.AddDefaultAuthentication();

            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IFormService, FormService>();

            builder.Services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });

            builder.Services.AddHttpContextAccessor();
        }
    }

}