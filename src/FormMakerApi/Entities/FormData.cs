using eShop.Identity.API.Models;
using System.ComponentModel.DataAnnotations;

namespace FormMakerApi.Entities
{
    public class FormData:BaseEntity
    {
        public int FormId { get; set; }
        public int FormTemplateId { get; set; }
        public ApplicationUser Assignee { get; set; }
        public List<ComponentData> ComponentDatas { get; set; }    
        public DateTime DoneDate { get; set; }
    }
    public class ComponentData
    {
        public int ComponentnId { get; set; }
        public ComponentValue Value { get; set; }
    }
    {
    public class ComponentValue

    {
        public int ComponentId { get;  set; }
        public string? Label { get;  set; }
        public string? Value { get;  set; }
    }


}
