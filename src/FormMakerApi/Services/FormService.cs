using FormMakerApi.Entities;
using FormMakerApi.Infrastructure;
using Grpc.Net.Client;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Data;

namespace FormMakerApi.Services
{
    public class FormService: IFormService
    {
        private readonly IRepository<FormData> _formdataRepository;
        private readonly IRepository<Form> _formRepository;
        private readonly IRepository<FormTemplate> _templateRepository;
        private GrpcChannel _channel;
        public FormService(IRepository<FormData> formdataRepository,
            IRepository<Form> formRepository,
            IRepository<FormTemplate> templateRepository)
        {
            _formdataRepository = formdataRepository;
            _formRepository = formRepository;
            _templateRepository = templateRepository;
        }
        public async Task<FormTemplate> GetFormWithData(int formId)
        {
            var formData = await _formdataRepository.FirstOrDefaultAsync(s => s.FormId == formId);
            var components = formData.ComponentDatas.ToList();
            var formTemplate = await _templateRepository.FirstOrDefaultAsync(s => s.Id == formData.FormTemplateId);
            formTemplate.Components.ForEach(c => {
                components.ForEach(e =>
                {
                    if (e.ComponentnId == c.Id)
                        c.InputValue = e.Value;
                });
            });
            return formTemplate;
        }
    }
}