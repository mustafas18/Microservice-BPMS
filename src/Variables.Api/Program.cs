
using Bpms.ServiceDefaults;
using BpmsVariables.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Variables.Extensions;

namespace Variables.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigurationManager Configuration = builder.Configuration;

        builder.AddServiceDefaults();
        builder.AddApplicationServices();


#if DEBUG
        builder.Services.AddDbContext<VariablesDbContext>(options =>
         options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
#else
                            builder.Services.AddDbContext<AppDbContext>(options =>
                             options.UseSqlServer(Configuration.GetConnectionString("ReleaseConnectionString")));
#endif

        builder.Services.AddProblemDetails();
        var withApiVersioning = builder.Services.AddApiVersioning();
        builder.AddDefaultOpenApi(withApiVersioning);

        var app = builder.Build();

        app.MapDefaultEndpoints();

        app.NewVersionedApi("Variables")
            .MapVariablesApi();


        app.UseDefaultOpenApi();
        app.Run();

    }
}
