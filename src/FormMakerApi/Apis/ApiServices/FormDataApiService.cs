using FormMakerApi.Entities;
using FormMakerApi.Infrastructure;

namespace FormMakerApi.Apis.ApiServices
{
    public class FormDataApiService(IRepository<FormData> repository,
        IRepository<Form> formRepository)
    {
        public IRepository<FormData> Repository { get; } = repository;
        public IRepository<Form> FormRepository { get; } = formRepository;
    }
}
