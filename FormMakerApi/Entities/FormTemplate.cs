using eShop.Identity.API.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FormMakerApi.Entities
{
    public class FormTemplate: BaseEntity
    {
        public FormTemplate()
        {
                
        }
        public string Title { get; private set; }
  
        public List<FormComponent> Components { get;private set; }
        public   ApplicationUser Creator { get; private set; }
        public int Version { get; private set; }

    }
    public class FormComponent
    {
        public int Id { get; private set; }
        public string Type { get; private set; }
        public string Label { get; private set; }
        public List<ElementValue>? Values { get; set; }
        public ElementValue? InputValue { get; set; }
        public int Order { get; private set; }
        public bool Readonly { get; private set; }
        public string? Tooltip { get; private set; }
    }
 
}
