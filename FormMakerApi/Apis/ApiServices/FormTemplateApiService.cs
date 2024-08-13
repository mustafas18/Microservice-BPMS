using FormMakerApi.Entities;
using FormMakerApi.Infrastructure;

namespace FormMakerApi.Apis.ApiServices
{
    public class FormTemplateApiService(IRepository<FormTemplate> repository)
    {
        public IRepository<FormTemplate> Repository { get; } = repository;
    }

}
