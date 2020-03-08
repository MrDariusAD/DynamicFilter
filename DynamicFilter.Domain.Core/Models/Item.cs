using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using DynamicFilter.Domain.Core.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DynamicFilter.Domain.Core.Models {
    public class Item {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonIgnoreIfNull]
        public string Name { get; set; }
        [BsonIgnoreIfDefault]
        public string Description { get; set; }
        [BsonIgnoreIfDefault]
        public List<Attribute> Attributes { get; set; }

        public List<AttributeGroup> AttributeGroups { get; set; }
        [BsonIgnoreIfDefault]
        public string IconUrl { get; set; }
        [BsonIgnoreIfDefault]
        public string WebsiteUrl { get; set; }


        public ItemReportModel ToReportModel() {
            return new ItemReportModel {
                Name = Name,
                Attributes = Attributes,
                Id = Id.ToString(),
                IconUrl = IconUrl,
                Description = Description,
                WebsiteUrl = WebsiteUrl,
                AttributeGroups = AttributeGroups
            };
        }

        public IEnumerable<Attribute> GetMergedAttributes() {
            if (Attributes != null && AttributeGroups != null) {
                return Attributes.Concat(AttributeGroups.SelectMany(x => x.Attributes));
            }
            if (Attributes == null && AttributeGroups != null) {
                return AttributeGroups.SelectMany(x => x.Attributes);
            }
            if (Attributes != null && AttributeGroups == null) {
                return Attributes;
            }
            return new List<Attribute>();
        }
    }
}