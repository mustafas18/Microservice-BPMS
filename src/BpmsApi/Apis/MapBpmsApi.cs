using BpmsApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BpmsApi.Apis
{
    public static class MapBpmsApi
    {
        public static IEndpointRouteBuilder MapBpmsApiV1(this IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("api/bpms")
                .HasApiVersion(1.0);

            // Routes for querying catalog items.
            api.MapGet("/15days", Get15DaysForcast);
            ;
            //api.MapGet("/items/by", GetItemsByIds);
            //api.MapGet("/items/{id:int}", GetItemById);
            //api.MapGet("/items/by/{name:minlength(1)}", GetItemsByName);
            //api.MapGet("/items/{catalogItemId:int}/pic", GetItemPictureById);

            //// Routes for resolving catalog items using AI.
            //api.MapGet("/items/withsemanticrelevance/{text:minlength(1)}", GetItemsBySemanticRelevance);

            //// Routes for resolving catalog items by type and brand.
            //api.MapGet("/items/type/{typeId}/brand/{brandId?}", GetItemsByBrandAndTypeId);
            //api.MapGet("/items/type/all/brand/{brandId:int?}", GetItemsByBrandId);
            //api.MapGet("/catalogtypes", async (CatalogContext context) => await context.CatalogTypes.OrderBy(x => x.Type).ToListAsync());
            //api.MapGet("/catalogbrands", async (CatalogContext context) => await context.CatalogBrands.OrderBy(x => x.Brand).ToListAsync());

            //// Routes for modifying catalog items.
            //api.MapPut("/items", UpdateItem);
            //api.MapPost("/items", CreateItem);
            //api.MapDelete("/items/{id:int}", DeleteItemById);

            return app;
        }


        public static List<string> Get15DaysForcast([AsParameters] WeatherForcast services)
        {
            return services.Forcast15Days();
        }

    }
}
