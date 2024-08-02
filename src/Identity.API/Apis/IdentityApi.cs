using Azure.Core;
using eShop.Identity.API.Models.AccountViewModels;
using eShop.ServiceDefaults;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;

namespace Identity.API.Apis
{
    public static class IdentityApi
    {
        public static IEndpointRouteBuilder MapIdentityApiV1(this IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("api/identity")
                .HasApiVersion(1.0);

            // Routes for querying catalog items.
            api.MapPost("/login", Login);
            api.MapGet("/token", async (HttpContext context) => "d");


            return api;
        }
        public static async Task<IResult> Login(
       [AsParameters] 
        AuthService service,
       LoginInputModel model)
        {
            var result = await service.SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberLogin, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                var user = await service.UserManager.FindByNameAsync(model.Username);
                await service.Events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName));
                return Results.Ok();
            }
            return Results.NoContent();

        }
    }
}
