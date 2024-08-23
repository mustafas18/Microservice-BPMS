using FormMakerApi.Entities;

namespace FormMakerApi.Dtos
{
    public class CreateFormDto
    {
        public int BpmId { get; set; }
        public int NodeId { get; set; }
        public List<string> AssigneesIds { get; set; }
        public List<ComponentData> componentDatas {  get; set; }
        public int TemplateId { get; set; }
        public string tenantId { get; set; }
    }
}
