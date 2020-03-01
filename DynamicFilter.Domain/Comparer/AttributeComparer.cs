using System.Collections.Generic;
using System.Text.Json.Serialization;
using DynamicFilter.Domain.Core.Models;
using Newtonsoft.Json;

namespace DynamicFilter.Domain.Comparer {
    public class AttributeComparer : IEqualityComparer<Attribute> {
        public bool Equals(Attribute item1, Attribute item2) {
            if (item2 == null && item1 == null)
                return true;
            else if (item1 == null || item2 == null)
                return false;
            item1.Value = "";
            item1.Weight = 1;
            item2.Value = "";
            item2.Weight = 1;
            var item1Json = JsonConvert.SerializeObject(item1);
            var item2Json = JsonConvert.SerializeObject(item2);
            return item1Json == item2Json;
        }

        bool IEqualityComparer<Attribute>.Equals(Attribute x, Attribute y) {
            return Equals(x, y);
        }

        int IEqualityComparer<Attribute>.GetHashCode(Attribute obj) {
            var hash = obj.Name.GetHashCode() ^ obj.Type.GetHashCode();
            return hash.GetHashCode();

        }
    }
}