using Duende.IdentityServer.Services;
using FormMakerApi.Entities;
using FormMakerApi.Infrastructure;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Data;

namespace FormMakerApi.Services
{
    public class FormService
    {
        private readonly IRepository<FormData> _formdataRepository;
        private readonly IRepository<Form> _formRepository;
        private readonly IRepository<FormTemplate> _templateRepository;

        public FormService(IRepository<FormData> formdataRepository,
            IRepository<Form> formRepository,
            IRepository<FormTemplate> templateRepository)
        {
            _formdataRepository = formdataRepository;
            _formRepository = formRepository;
            _templateRepository = templateRepository;
        }
        public async Task<FormTemplate> RenderFormWithData(int formId)
        {
            var formData = await _formdataRepository.FirstOrDefaultAsync(s => s.FormId == formId);
            var elements = formData.ArcheType.ElementValues;
            var formTemplate = await _templateRepository.FirstOrDefaultAsync(s => s.Id == formData.ArcheType.FormTemplateId);
            formTemplate.Components.ForEach(c => {
                elements.ForEach(e =>
                {
                    if (e.ElementId == c.ElementId)
                        c.InputValue = e.Value;
                });
            });
            return formTemplate;
        }
    }
}