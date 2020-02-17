using System.Collections.Generic;
using DynamicFilter.Domain.Core.Models;
using MongoDB.Bson;

namespace DynamicFilter.Domain.Core.Models {
    public class ItemReportModel {
        public string Id { get; set; }
        public List<Attribute> Attributes { get; set; }
    }
}