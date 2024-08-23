using FormMakerApi.Entities;

namespace FormMaker.Dtos
{
    public class CreateFormDataDto
    {
        public int FormId { get; set; }
        public int FormTemplateId { get; set; }
        public string AssigneeId { get; set; }
        public List<ComponentData>? ComponentDatas { get; set; }
        public DateTime? DoneDate { get; set; }
    }
}
