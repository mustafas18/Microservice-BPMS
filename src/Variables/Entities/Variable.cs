using Variables.Enums;

namespace Variables.Entities
{
    public class Variable
    {
        public string Name { get; set; }
        public DataTypeEnum DataType { get; set; }
        public string Value { get; set; }
    }
}
