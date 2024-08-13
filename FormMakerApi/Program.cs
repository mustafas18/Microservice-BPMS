
using FormMakerApi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FormMakerApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigurationManager Configuration = builder.Configuration;

        builder.AddServiceDefaults();
        builder.AddApplicationServices();


        #if DEBUG
                builder.Services.AddDbContext<FormDbContext>(options =>
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

        app.NewVersionedApi("formmaker")
            .FormApiV1();

        app.UseDefaultOpenApi();
        app.Run();

    }
}
