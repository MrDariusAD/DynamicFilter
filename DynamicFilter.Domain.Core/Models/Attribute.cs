using System.Reflection.Metadata.Ecma335;

namespace DynamicFilter.Domain.Core {
  public class Attribute {
    public string Name { get; set; }
    public string Value { get; set;}
    public AttributeType Type { get; set; }
  }
}