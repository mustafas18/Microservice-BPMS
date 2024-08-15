using FormMakerApi.Entities;
using FormMakerApi.Infrastructure;

namespace FormMakerApi.Apis.ApiServices
{
    public class FormDataApiService(IRepository<FormData> repository)
    {
        public IRepository<FormData> Repository { get; } = repository;
    }
}
