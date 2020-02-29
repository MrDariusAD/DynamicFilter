using System.Collections.Generic;
using DynamicFilter.Domain.Core.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DynamicFilter.Domain.Core.Models {
    public class ItemWithoutId {
        [BsonIgnoreIfNull]
        public string Name { get; set; }
        [BsonIgnoreIfDefault]
        public List<Attribute> Attributes { get; set; }

        public ItemReportModel ToReportModel() {
            return new ItemReportModel {
                Name = Name,
                Attributes = Attributes
            };
        }
    }
}