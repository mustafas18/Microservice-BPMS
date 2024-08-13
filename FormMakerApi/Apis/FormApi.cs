using FormMakerApi.Apis.ApiServices;
using FormMakerApi.Entities;

namespace FormMakerApi.Apis
{
    public static class FormApi
    {
        public static IEndpointRouteBuilder MapFormApi(this IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("api/form")
                .HasApiVersion(1.0);

            api.MapGet("/FormTemplates", GetFormTemplate).RequireAuthorization();
            api.MapGet("/FormTemplateById", GetFormTemplateById).RequireAuthorization();
            api.MapPost("/CreateFormTemplate", CreateFormTemplate).RequireAuthorization();
            api.MapPut("/UpdateFormTemplate", UpdateFormTemplate).RequireAuthorization();
            api.MapDelete("/DeleteFormTemplate", DeleteFormTemplate).RequireAuthorization();


            api.MapGet("/FormById", FormById).RequireAuthorization();
            api.MapPost("/CreateForm", CreateForm).RequireAuthorization();
            api.MapPut("/UpdateForm", UpdateForm).RequireAuthorization();
            api.MapDelete("/DeleteForm", DeleteForm).RequireAuthorization();

            api.MapGet("/FormDataById", FormDataById).RequireAuthorization();
            api.MapPost("/CreateFormData", CreateFormData).RequireAuthorization();
            api.MapPut("/UpdateFormData", UpdateFormData).RequireAuthorization();
            return app;
        }


        public static List<FormTemplate> GetFormTemplate([AsParameters] FormTemplateApiService services)
        {
            return services.Repository.        }
        public static FormTemplate GetFormTemplateById([AsParameters] FormTemplateApiService services)
        {
            return services.Repository.GetAll();
        }
        public static async FormTemplate CreateFormTemplate([AsParameters] FormTemplateApiService services,FormTemplate formTemplate)
        {
            return await services.Repository.AddAsync(formTemplate);
        }
        public static async FormTemplate UpdateFormTemplate([AsParameters] FormTemplateApiService services, FormTemplate formTemplate)
        {
            return await services.Repository.UpdateAsync(formTemplate);
        }
        public static bool DeleteFormTemplate([AsParameters] FormTemplateApiService services,int id)
        {
            return services.Repository.Delete(id);
        }
    }
}
