namespace DynamicFilter.Domain.Core.Models {
    public class SearchAttributeModel {
        public string Name { get; set; }
        public AttributeType Type { get; set; }
        public string[] Values { get; set; }
        public double Weight { get; set; }
    }
}