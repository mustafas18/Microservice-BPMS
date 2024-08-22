using Aspire.Hosting;


internal class Program
{
    private static void Main(string[] args)
    {
        var launchProfileName = ShouldUseHttpForEndpoints() ? "http" : "https";

        var builder = DistributedApplication.CreateBuilder(args);


        var identityApi = builder.AddProject<Projects.Identity>("identity-api", launchProfileName)
            .WithExternalHttpEndpoints();

        var identityEndpoint = identityApi.GetEndpoint(launchProfileName);

        var bpmsApi = builder.AddProject<Projects.Bpms_Api>("bpms-api")
            .WithEnvironment("Identity__Url", identityEndpoint);

        var formMaker = builder.AddProject<Projects.FormMaker>("formmaker-api")
           .WithEnvironment("Identity__Url", identityEndpoint);
        ;

        // Identity has a reference to all of the apps for callback urls, this is a cyclic reference
        identityApi.WithEnvironment("bpms-api", bpmsApi.GetEndpoint("http"));
        //          .WithEnvironment("bpms-api", bpmsApi.GetEndpoint("http"));

        builder.Build().Run();

        // For test use only.
        // Looks for an environment variable that forces the use of HTTP for all the endpoints. We
        // are doing this for ease of running the Playwright tests in CI.
        static bool ShouldUseHttpForEndpoints()
        {
            const string EnvVarName = "ESHOP_USE_HTTP_ENDPOINTS";
            var envValue = Environment.GetEnvironmentVariable(EnvVarName);

            // Attempt to parse the environment variable value; return true if it's exactly "1".
            return int.TryParse(envValue, out int result) && result == 1;
        }
    }
}