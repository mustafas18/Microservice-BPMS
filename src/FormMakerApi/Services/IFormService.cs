using FormMakerApi.Entities;

namespace FormMakerApi.Services
{
    public interface IFormService
    {
        Task<FormTemplate> GetFormWithData(int formId);
    }
}
