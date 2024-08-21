using FormMakerApi.Apis.ApiServices;
using FormMakerApi.Dtos;
using FormMakerApi.Entities;

namespace FormMakerApi.Apis
{
    public static class FormTemplateApi
    {
        public static IEndpointRouteBuilder MapFormTemplateApi(this IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("api/FormTemplate")
                .HasApiVersion(1.0);

            api.MapGet("/FormTemplates", GetFormTemplate).RequireAuthorization();
            api.MapGet("/FormTemplateById", GetFormTemplateById).RequireAuthorization();
            api.MapPost("/CreateFormTemplate", CreateFormTemplate).RequireAuthorization();
            api.MapPut("/UpdateFormTemplate", UpdateFormTemplate).RequireAuthorization();
            api.MapDelete("/DeleteFormTemplate", DeleteFormTemplate).RequireAuthorization();
            return app;
        }
            public static async Task<List<FormTemplate>> GetFormTemplate([AsParameters] FormTemplateApiService services)
        {
            return await services.Repository.GetAllAsync();
        }
        public static async Task<FormTemplate> GetFormTemplateById([AsParameters] FormTemplateApiService services, int id)
        {
            return await services.Repository.FirstOrDefaultAsync(s => s.Id == id);
        }
        public static async Task<FormTemplate> CreateFormTemplate([AsParameters] FormTemplateApiService services, CreateFormTemplateDto model)
        {
            var formTemplate = new FormTemplate(model.Title, model.Components, model.CreatorId, 1,model.TenantId);
            return await services.Repository.AddAsync(formTemplate);
        }
        public static async Task<FormTemplate> UpdateFormTemplate([AsParameters] FormTemplateApiService services, UpdateFormTemplateDto model)
        {
            var formTemplate = services.Repository.FirstOrDefault(s => s.Id == model.Id);
            formTemplate = formTemplate.Update(model);
            return await services.Repository.UpdateAsync(formTemplate);
        }
        public static async Task<bool> DeleteFormTemplate([AsParameters] FormTemplateApiService services, int id)
        {
            var formTemplate = services.Repository.FirstOrDefault(s => s.Id == id);
            if (formTemplate != null)
            {
                await services.Repository.DeleteAsync(formTemplate);
                return true;
            }
            else
            {
                throw new Exception("The form template is not found.");
            }

        }

    }
}
