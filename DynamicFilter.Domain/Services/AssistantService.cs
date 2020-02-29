using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DynamicFilter.Domain.Core;
using DynamicFilter.Domain.Core.Models;

namespace DynamicFilter.Domain.Services {
    public class AssistantService {
        public static List<AssistantResultReportModel> CalculateOptimalItems(AssistantRequestReportModel reportModel,
            List<Item> items) {
            var result = new List<AssistantResultReportModel>();
            foreach (var item in items) {
                var percent = decimal.Zero;
                foreach (var preferenceAttribute in reportModel.PreferenceAttributes) {
                    if (item.Attributes.Select(attr => attr.Name).Contains(preferenceAttribute.Name) &&
                        item.Attributes.FirstOrDefault(x => x.Name == preferenceAttribute.Name)?.Value ==
                        preferenceAttribute.Value) {
                        percent += preferenceAttribute.Weight / reportModel.PreferenceAttributes.Sum(x=> x.Weight) * 100;
                    }
                }
                result.Add(new AssistantResultReportModel { Item = item, RateInPercent = Math.Round(percent, 2) });
            }
            return result.OrderByDescending(x => x.RateInPercent).ToList();
        }
    }
}