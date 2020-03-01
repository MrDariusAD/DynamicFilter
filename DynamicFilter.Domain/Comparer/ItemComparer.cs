using System.Collections.Generic;
using System.Text.Json.Serialization;
using DynamicFilter.Domain.Core.Models;
using Newtonsoft.Json;

namespace DynamicFilter.Domain.Comparer {
    public class ItemComparer : IEqualityComparer<Item> {
        public bool Equals(Item item1, Item item2) {
            if (item2 == null && item1 == null)
                return true;
            else if (item1 == null || item2 == null)
                return false;
            var item1Json = JsonConvert.SerializeObject(item1);
            var item2Json = JsonConvert.SerializeObject(item2);
            return item1Json == item2Json;
        }

        bool IEqualityComparer<Item>.Equals(Item x, Item y) {
            return Equals(x,y);
        }

        int IEqualityComparer<Item>.GetHashCode(Item obj) {
            var objJson = JsonConvert.SerializeObject(obj);
            return objJson.GetHashCode();

        }
    }
}