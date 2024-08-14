using FormMakerApi.Entities;
using FormMakerApi.Infrastructure;

namespace FormMakerApi.Apis.ApiServices
{
    public class FormApiService(IRepository<Form> repository)
    {
        public IRepository<Form> Repository { get; } = repository;
    }
}
