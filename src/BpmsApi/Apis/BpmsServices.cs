using AutoMapper;
using Bpms.Services.Identity;
using BpmsDomain.Entities;
using BPMSDomain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BpmsApi.Apis
{
    public class BpmsServices(
        IMapper mapper,
        IIdentityService identityService,
        IRepository<WorkflowTemplate> workflowTemplateRepository)
    {
        public IMapper DataMapper { get; } = mapper;
        public IIdentityService IdentityService { get; } = identityService;
        public IRepository<WorkflowTemplate> WorkflowTemplateRepository { get; } = workflowTemplateRepository;
    }
}
