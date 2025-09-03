
using BpmsApi.Apis;
using BpmsApi.Extensions;
using BPMS.Infrastructure;
using Bpms.ServiceDefaults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;
using static System.Net.WebRequestMethods;
using Bpms.Api.Apis;

namespace BpmsApi;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        ConfigurationManager Configuration = builder.Configuration;

        builder.AddServiceDefaults();
        builder.AddApplicationServices();


#if DEBUG
        builder.Services.AddDbContext<BpmsDbContext>(options =>
         options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
#else
                    builder.Services.AddDbContext<AppDbContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("ReleaseConnectionString")));
#endif
        builder.AddCorsPolicy("myCorsPolicy");

        builder.Services.AddProblemDetails();

        builder.Services.AddHttpContextAccessor();

        // Register an HttpClient in BpmsApi
        builder.Services
            .AddHttpClient<IVariablesClient, VariablesClient>((sp, http) =>
            {
                var cfg = sp.GetRequiredService<IConfiguration>();
                http.BaseAddress = new Uri(cfg["Variables:Url"]!);
            })
            .AddHttpMessageHandler<BearerForwardingHandler>();
        builder.Services.AddTransient<BearerForwardingHandler>();


        builder.Services.AddAutoMapper(typeof(Program));


        builder.Services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });

        var withApiVersioning = builder.Services.AddApiVersioning();
        builder.AddDefaultOpenApi(withApiVersioning);


        var app = builder.Build();

        app.MapDefaultEndpoints();
        
        app.UseCors("myCorsPolicy");

        app.NewVersionedApi("Workflow Template")
            .RequireAuthorization()
            .WorkflowTemplateV1();

        app.NewVersionedApi("Workflow Designer")
            .RequireAuthorization()
            .MapWorkflowDesignApiV1();
        
        app.UseDefaultOpenApi();
        app.Run();

    }
}
