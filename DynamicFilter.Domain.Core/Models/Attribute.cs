using MongoDB.Bson.Serialization.Attributes;

namespace DynamicFilter.Domain.Core.Models {
    public class Attribute {
        public string Name { get; set; }
        public string Value { get; set; }
        public AttributeType Type { get; set; }
        [BsonIgnoreIfDefault]
        public decimal Weight { get; set; }

        public SearchAttributeModel ToSearchAttributeModel(string[] values) {
            return new SearchAttributeModel {
                Name = Name,
                Type = Type,
                Values = values
            };
        }
    }
}