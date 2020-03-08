using System.Collections.Generic;

namespace DynamicFilter.Domain.Core.Models {
    public class SearchAttributeGroupModel {
        public string Name { get; set; }
        public List<SearchAttributeModel> Attributes { get; set; }
    }
}