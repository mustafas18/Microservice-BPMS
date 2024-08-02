using Microsoft.AspNetCore.Routing;

namespace Identity.API.Apis
{
    public static class IdentityApi
    {
        public static IEndpointRouteBuilder MapIdentityApiV1(this IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("api/bpms")
                .HasApiVersion(1.0);

            // Routes for querying catalog items.
            api.MapGet("/15days", ()=>"sdf");
            return api;
        }
    }
}
