using System.Collections.Generic;

namespace DynamicFilter.Domain.Core.Models {
    public class PresentAttributesReportModel {
        public List<SearchAttributeModel> Attributes { get; set; }
        public List<SearchAttributeGroupModel> AttributeGroups { get; set; }
    }
}