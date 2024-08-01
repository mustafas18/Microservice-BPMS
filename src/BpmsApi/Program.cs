
using BpmsApi.Apis;
using BpmsApi.Extensions;
using BpmsApi.Infrastructure;
using eShop.ServiceDefaults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;
using static System.Net.WebRequestMethods;

namespace BpmsApi;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        ConfigurationManager Configuration = builder.Configuration;

        builder.AddServiceDefaults();
        builder.AddApplicationServices();


        //#if DEBUG
        //        builder.Services.AddDbContext<AppDbContext>(options =>
        //         options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
        //#else
        //            builder.Services.AddDbContext<AppDbContext>(options =>
        //             options.UseSqlServer(Configuration.GetConnectionString("ReleaseConnectionString")));
        //#endif

        builder.Services.AddProblemDetails();
        var withApiVersioning = builder.Services.AddApiVersioning();
        builder.AddDefaultOpenApi(withApiVersioning);

        var app = builder.Build();

        app.MapDefaultEndpoints();

        app.NewVersionedApi("bpms")
            .MapBpmsApiV1();
       
        app.UseDefaultOpenApi();
        app.Run();

    }
}
