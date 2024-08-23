


using FormMaker.Enums;

namespace FormMakerApi.Entities
{
    public class Form : BaseEntity
    {
        public Form() { }
        public Form(int bpmId,
                    int nodeId,
                    List<string> assignees,
                    FormTemplate template,
                    List<ComponentData> componentDatas,
                    string tenantId) : base(tenantId)
        {
            BpmId = bpmId;
            NodeId = nodeId;
            Assignees = assignees;
            Template = template;
            TenantId = tenantId;
            ComponentDatas = componentDatas;
        }
        public int BpmId { get; set; }
        public int NodeId { get; set; }
        public List<string> Assignees { get; set; }
        public FormTemplate Template { get; set; }
        public List<ComponentData>? ComponentDatas { get; set; }
        public DateTime? DueDateTime { get; set; }
        public PriorityEnum PriorityStatus {  get; set; }
    }
}
