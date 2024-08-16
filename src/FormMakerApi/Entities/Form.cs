


using FormMaker.Enums;

namespace FormMakerApi.Entities
{
    public class Form:BaseEntity
    {
        public Form() { }
        public Form(int bpmId,
                    int nodeId,
                    List<string> assignees,
                    FormTemplate template,
                    string tenantId):base(tenantId)
        {
            BpmId = bpmId;
            NodeId = nodeId;
            Assignees = assignees;
            Template = template;
            TenantId = tenantId;
        }
        public int BpmId { get; set; }
        public int NodeId { get; set; }
        public List<string> Assignees { get; set; }
        public FormTemplate Template { get; set; }
        public DateTime? DueDateTime { get; set; }
        public PriorityEnum PriorityStatus {  get; set; }
    }
}
