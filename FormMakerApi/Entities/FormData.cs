using eShop.Identity.API.Models;

namespace FormMakerApi.Entities
{
    public class FormData:BaseEntity
    {
        public int FormId { get; set; }
        public ApplicationUser Assignee { get; set; }
        public Archetype ArcheType { get; set; }    
        public DateTime FormDate { get; set; }
    }
    public class Archetype:BaseEntity
    {
        public int FormTemplateId { get; set; }
        public List<ElementValue> ElementValues { get; set; }
    }

    
}
