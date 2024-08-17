using FormMaker.Entities;
using FormMakerApi.Entities;

namespace FormMakerApi.Dtos
{
    public class CreateFormTemplateDto
    {
        public string Title { get; set; }
        public List<FormComponent> Components { get;  set; }
        public string CreatorId { get;  set; }
    }
}
