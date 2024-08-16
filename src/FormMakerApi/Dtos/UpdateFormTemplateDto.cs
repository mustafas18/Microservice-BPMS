using FormMaker.Entities;
using FormMakerApi.Entities;

namespace FormMakerApi.Dtos
{
    public class UpdateFormTemplateDto
    {
        public int Id { get; set; }  
        public string Title { get; set; }
        public List<FormComponent> Components { get; set; }
    }
}
