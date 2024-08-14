using System.ComponentModel.DataAnnotations;

namespace FormMakerApi.Entities
{
    public class ElementValue
       
    {
        [Required]
        public int Id { get;private set; }
        public int ElementId { get; private set; }
        public string? Label { get; private set; }
        public string? Value { get; private set; }
    }
}
