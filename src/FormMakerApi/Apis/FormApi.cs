using FormMakerApi.Apis.ApiServices;
using FormMakerApi.Dtos;
using FormMakerApi.Entities;

namespace FormMakerApi.Apis
{
    public  static class FormApi
    {

        public static IEndpointRouteBuilder MapFormApi(this IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("api/Form")
                .HasApiVersion(1.0);
            api.MapGet("/FormById", GetFormById).RequireAuthorization();
            api.MapPost("/CreateForm", CreateForm).RequireAuthorization();
            api.MapPut("/UpdateForm", UpdateForm).RequireAuthorization();
            api.MapDelete("/DeleteForm", DeleteForm).RequireAuthorization();

            api.MapGet("/GetFormWithData", GetFormWithData).RequireAuthorization();
            return app;

        }
            public static async Task<Form> GetFormById([AsParameters] FormApiService services, int id)
        {
            return await services.Repository.FirstOrDefaultAsync(s => s.Id == id);
        }
        public static async Task<Form> CreateForm([AsParameters] FormApiService services, CreateFormDto model)
        {
            var template = services.TemplateRepository.AsNoTracking()
                            .FirstOrDefault(s => s.Id == model.TemplateId);
            var form = new Form(model.BpmId,model.NodeId,model.AssigneesIds, template,model.tenantId);
            return await services.Repository.AddAsync(form);
        }
        public static async Task<Form> UpdateForm([AsParameters] FormApiService services, Form form)
        {
            return await services.Repository.UpdateAsync(form);
        }
        public static async Task<bool> DeleteForm([AsParameters] FormApiService services, int id)
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
        public static async Task<FormTemplate> GetFormWithData([AsParameters] FormApiService services, int formId)
        {
            return await services.FormService.GetFormWithData(formId);
        }
        
    }
}
