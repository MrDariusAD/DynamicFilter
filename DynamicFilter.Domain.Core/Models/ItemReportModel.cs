﻿using System.Collections.Generic;
using DynamicFilter.Domain.Core.Models;
using MongoDB.Bson;

namespace DynamicFilter.Domain.Core.Models {
    public class ItemReportModel {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Attribute> Attributes { get; set; }
        public List<AttributeGroup> AttributeGroups { get; set; }

        public string IconUrl { get; set; }
        public string WebsiteUrl { get; set; }
    }
}