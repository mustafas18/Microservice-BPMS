using BPMS.Domain.Dtos;
using BPMS.Domain.Entities;
using BpmsDomain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BpmsApi.Apis
{
    public static class MapWorkflowDesignApi
    {
        public static IEndpointRouteBuilder MapWorkflowDesignApiV1(this IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("api/workflow")
                .HasApiVersion(1.0);

          
            
            api.MapPut("/Nodes/Update", UpdateNodes);
            api.MapPost("/Node/CreateUpdate", CreateUpdateNode);

            // Routes for get identity info
            api.MapGet("/identity", GetIdentity).RequireAuthorization();
            api.MapGet("/identity/acceess_token", GetAccessToken);

            return app;
        }
       
        public static List<NodeDto> UpdateNodes([AsParameters] BpmsServices services,List<NodeDto> nodes)
        {
            return nodes;
        }
        public static async Task<WorkflowTemplate> CreateUpdateNode([AsParameters] BpmsServices services, NodeDto node)
        {
            var template = await services.WorkflowTemplateRepository
                 .Include("Nodes")
                 .FirstOrDefaultAsync(s => s.Id == node.WorkflowId);
            if (node.Id != 0)
            {
                template.AddNode(services.DataMapper.Map<NodeDto, Node>(node));
            }
            else
            {
                template.UpdateNode(services.DataMapper.Map<NodeDto, Node>(node));
            }
            await services.WorkflowTemplateRepository.SaveChangesAsync();
            return template;
        }

        
        public static string GetIdentity([AsParameters] BpmsServices services)
        {
            return services.IdentityService.GetUserIdentity();
        }
        public static string GetAccessToken([AsParameters] BpmsServices services)
        {
            return services.IdentityService.GetAccesssToken() ?? "null";
        }
    }
}
