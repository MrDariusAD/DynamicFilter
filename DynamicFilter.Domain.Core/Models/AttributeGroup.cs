using System.Collections.Generic;


namespace DynamicFilter.Domain.Core.Models {
    public class AttributeGroup {
        public string Name { get; set; }
        public List<Attribute> Attributes { get; set; }
    }
}