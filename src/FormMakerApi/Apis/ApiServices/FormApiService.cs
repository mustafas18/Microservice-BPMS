using FormMakerApi.Entities;
using FormMakerApi.Infrastructure;
using FormMakerApi.Services;

namespace FormMakerApi.Apis.ApiServices
{
    public class FormApiService(IRepository<Form> repository,IFormService formService,
        IRepository<FormTemplate> templateRepository)
    {
        public IRepository<Form> Repository { get; } = repository;
        public IRepository<FormTemplate> TemplateRepository { get; } = templateRepository;
        public IFormService FormService { get; } = formService;
    }
}
