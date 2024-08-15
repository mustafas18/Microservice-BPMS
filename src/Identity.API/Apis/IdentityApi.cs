using Azure.Core;
using eShop.Identity.API.Models.AccountViewModels;
using eShop.ServiceDefaults;
using IdentityModel.Client;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using static System.Net.WebRequestMethods;

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
            api.MapGet("/token",  async (HttpContext context) => await context.GetTokenAsync("access_token"));
            api.MapGet("/getUserById", GetUserById);


            return api;
        }
        public static async Task<IResult> Login(
       [AsParameters] 
        AuthService service,
       IHttpClientFactory client,
       LoginInputModel model)
        {
           var identityConfig= service.Configuration.GetSection("Identity");
          var identityUrl =   identityConfig.GetRequiredValue("Url");


            ///var httpClient = service.HttpClientFactory.CreateClient();
            //var res = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            //{
            //    Address = identityUrl + "/connect/token",
            //    ClientId = "webapp",
            //    ClientSecret = "secret",
            //    Scope="bpms formmaker variables",


            //});

            var httpClient = service.HttpClientFactory.CreateClient();
            var res = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = identityUrl + "/connect/token",
                ClientId = "webapp",
                ClientSecret = "secret",
                //Scope = "bpms",
                UserName ="alice",
                 Password="Pass123$"
            });
            var accessToken = res.AccessToken;

            //var result = await service.SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberLogin, lockoutOnFailure: true);
            //if (result.Succeeded)
            //{
            //    var user = await service.UserManager.FindByNameAsync(model.Username);
            //       await service.Events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName));

                
            //    return Results.Ok(accessToken);
            //}

            return Results.Ok(accessToken);

        }
        public static async Task<IResult> GetUserById(
         [AsParameters]
        AuthService service,
         IHttpClientFactory client,
         string userId)
        {
           var result=await service.UserManager.FindByIdAsync(userId);
            return Results.Ok(result);

        }

    }
}
