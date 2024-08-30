using AutoMapper;
using Bpms.Services.Identity;
using BPMS.Domain.Entities;
using BpmsDomain.Entities;
using BPMSDomain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BpmsApi.Apis
{
    public class BpmsServices
    {
        public BpmsServices(IMapper dataMapper,
            IRepository<WorkflowTemplate> workflowTemplateRepository) 
        {
            DataMapper = dataMapper;
            WorkflowTemplateRepository = workflowTemplateRepository;
        }

        public IMapper DataMapper { get; }
        public IRepository<WorkflowTemplate> WorkflowTemplateRepository { get; }
    }
    
}
