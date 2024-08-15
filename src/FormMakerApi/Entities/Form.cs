

using eShop.Identity.API.Models;

namespace FormMakerApi.Entities
{
    public class Form:BaseEntity
    {
        public Form() { }
        public Form(int bpmId,
                    int nodeId,
                    List<ApplicationUser> assignees,
                    FormTemplate template)
        {
            BpmId = bpmId;
            NodeId = nodeId;
            Assignees = assignees;
            Template = template;
        }
        public int BpmId { get; set; }
        public int NodeId { get; set; }
        public List<ApplicationUser> Assignees { get; set; }
        public FormTemplate Template { get; set; }
        
    }
}
