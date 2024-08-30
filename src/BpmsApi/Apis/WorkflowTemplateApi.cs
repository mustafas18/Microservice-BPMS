using BPMS.Domain.Dtos;
using BPMS.Domain.Entities;
using BpmsApi.Apis;
using BpmsDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bpms.Api.Apis
{
    public static class WorkflowTemplateApi
    {
        public static IEndpointRouteBuilder WorkflowTemplateV1(this IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("api/WorkflowTemplate")
                .HasApiVersion(1.0);

            // Routes
            api.MapGet("/GetAll", GetWorkflowTemplates).AllowAnonymous();
            api.MapGet("/GetById", GetWorkflowTemplateById).AllowAnonymous();
            api.MapPost("/Create", CreateWorkflowTemplate);
            api.MapPut("/Update", UpdateWorkflowTemplate);
            
            return app;
        }
        public static async Task<List<WorkflowTemplate>> GetWorkflowTemplates([AsParameters] BpmsServices services)
        {
            var templates = await services.WorkflowTemplateRepository
                                .AsNoTracking()
                                .ToListAsync();
            return templates;
        }
        public static async Task<WorkflowTemplate> GetWorkflowTemplateById([AsParameters] BpmsServices services, int templateId)
        {
            var template = await services.WorkflowTemplateRepository
                 .Include("Nodes")
                 .FirstOrDefaultAsync(s => s.Id == templateId);
            return template;
        }
        public static WorkflowTemplate CreateWorkflowTemplate([AsParameters] BpmsServices services, WorkflowTemplateDto workflow)
        {
            var template = new WorkflowTemplate(workflow.Name, workflow.Description);
            services.WorkflowTemplateRepository.AddAsync(template);
            return template;
        }
        public static async Task<WorkflowTemplate> UpdateWorkflowTemplate([AsParameters] BpmsServices services, WorkflowTemplateDto workflow)
        {
            var template = await services.WorkflowTemplateRepository
                  .FirstOrDefaultAsync(s => s.Id == workflow.Id);
            template = template.UpdateInfo(workflow.Name, workflow.Description);
            await services.WorkflowTemplateRepository.UpdateAsync(template);
            return template;
        }

    }
}
