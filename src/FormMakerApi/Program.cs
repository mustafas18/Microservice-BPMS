using eShop.ServiceDefaults;
using FormMaker.Extensions;
using FormMakerApi.Apis;
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

        app.NewVersionedApi("Form Template")
            .MapFormTemplateApi();

        app.NewVersionedApi("Form")
            .MapFormApi();

        app.NewVersionedApi("FormData")
            .MapFormDataApi();

        app.UseDefaultOpenApi();
        app.Run();

    }
}
