using FormMaker.Enums;
using FormMakerApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace FormMaker.Entities
{
    public class FormComponent
    {
        public FormComponent() { }
        [Required]
        public int Id { get; set; }
        public ComponentTypeEnum Type { get;  set; }
        public string Label { get;  set; }
        public List<ComponentValue>? Values { get; set; }
        public ComponentValue? InputValue { get; set; }
        public int Order { get;  set; }
        public bool Readonly { get;  set; }
        public string? Tooltip { get;  set; }
    }
    public class ComponentValue

    {
        public int ComponentId { get; set; }
        public string? Label { get; set; }
        public string? Value { get; set; }
    }

}
