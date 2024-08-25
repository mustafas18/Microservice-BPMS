using FormMakerApi.Entities;
using FormMakerApi.Infrastructure;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using Shared.Extensions;

namespace FormMakerApi.Services
{
    public class FormService: IFormService
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
        public async Task<FormTemplate> GetFormWithData(int formId)
        {
            var formData = await _formdataRepository.FirstOrDefaultAsync(s => s.FormId == formId);
            var components = formData.ComponentDatas.ToList();
            components = replaceVariablesWithValues(formData);
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
        private List<ComponentData> replaceVariablesWithValues(FormData formData)
        {
            var datas = formData.ComponentDatas.ToList();
            foreach (var data in datas)
            {
                var value = data.Value.Value;
                if (value!=null && value!="")
                {
                    while (Regex.IsMatch(value, @"@@(.*?)@@"))
                    {
                        var variableName = StringBetween.GetStringBetweenDelimiters(value, "@@");
                        var workflowId = _formRepository.FirstOrDefault(s => s.Id == formData.FormId).BpmId;
                        // TODO: get variable value of variableName
                        var variableValue = "Not Implemeted";//GetVariableValue(variableName, workflowId);
                        data.Value.Value = value.Replace($@"@@{variableName}@@", variableValue);
                    }
                }   
            }
            return datas;
        }
    }
}