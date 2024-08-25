namespace Variables.Api.Api
{
    public static class VariablesApi
    {

        public static IEndpointRouteBuilder MapVariablesApi(this IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("api/bpms")
                .HasApiVersion(1.0);
            return app;
        }


    }
}
