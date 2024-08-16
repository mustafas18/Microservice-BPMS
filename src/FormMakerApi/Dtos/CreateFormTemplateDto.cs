using FormMaker.Entities;
using FormMakerApi.Entities;

namespace FormMakerApi.Dtos
{
    public class CreateFormTemplateDto
    {
        public string Title { get; private set; }
        public List<FormComponent> Components { get;  set; }
        public string CreatorId { get;  set; }
    }
}
