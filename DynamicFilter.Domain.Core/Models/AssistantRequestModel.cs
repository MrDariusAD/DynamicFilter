using System.Collections.Generic;
using System.Linq;
using DynamicFilter.Domain.Core.Models;

namespace DynamicFilter.Domain.Core.Models {
    public class AssistantRequestModel {
        public List<Attribute> PreferenceAttributes { get; set; }
        public List<AttributeGroup> PreferenceAttributeGroups { get; set; }

        public IEnumerable<Attribute> GetMergedAttributes() {
            if (PreferenceAttributes != null && PreferenceAttributeGroups != null) {
                return PreferenceAttributes.Concat(PreferenceAttributeGroups.SelectMany(x => x.Attributes));
            }
            if (PreferenceAttributes == null && PreferenceAttributeGroups != null) {
                return PreferenceAttributeGroups.SelectMany(x => x.Attributes);
            }
            if (PreferenceAttributes != null && PreferenceAttributeGroups == null) {
                return PreferenceAttributes;
            }
            return new List<Attribute>();
        }
    }
}