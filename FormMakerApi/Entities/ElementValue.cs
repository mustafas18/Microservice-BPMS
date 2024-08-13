namespace FormMakerApi.Entities
{
    public class ElementValue : BaseEntity
    {
        public int ElementId { get; private set; }
        public string Label { get; private set; }
        public string Value { get; private set; }
    }
}
