using FormMakerApi.Apis.ApiServices;
using FormMakerApi.Entities;

namespace FormMakerApi.Apis
{
    public static class FormDataApi
    {
        public static IEndpointRouteBuilder MapFormDataApi(this IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("api/FormData")
                .HasApiVersion(1.0);

       
            api.MapGet("/FormDataById", GetFormDataById).RequireAuthorization();
            api.MapPost("/CreateFormData", CreateFormData).RequireAuthorization();
            api.MapPut("/UpdateFormData", UpdateFormData).RequireAuthorization();
            return app;
        }
        public static async Task<FormData> GetFormDataById([AsParameters] FormDataApiService services, int id)
        {
            return await services.Repository.FirstOrDefaultAsync(s => s.Id == id);
        }
        public static async Task<FormData> CreateFormData([AsParameters] FormDataApiService services, FormData formData)
        {
            return await services.Repository.AddAsync(formData);
        }
        public static async Task<FormData> UpdateFormData([AsParameters] FormDataApiService services, FormData formData)
        {
            return await services.Repository.UpdateAsync(formData);
        }
        public static async Task<bool> DeleteFormData([AsParameters] FormDataApiService services, int id)
        {
            var form = services.Repository.FirstOrDefault(s => s.Id == id);
            if (form != null)
            {
                await services.Repository.DeleteAsync(form);
                return true;
            }
            else
            {
                throw new Exception("The form is not found.");
            }

        }


    }
}
