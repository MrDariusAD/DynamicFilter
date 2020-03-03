using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DynamicFilter.Domain.Core;
using DynamicFilter.Domain.Core.Models;

namespace DynamicFilter.Domain.Services {
    public static class AssistantService {
        public static AssistantResultModel CalculateOptimalItems(AssistantRequestModel model,
            List<Item> items) {
            var result = new List<AssistantResultItemModel>();
            foreach (var item in items) {
                double percent = 0;
                foreach (var preferenceAttribute in model.PreferenceAttributes) {
                    if (item.Attributes.Select(attr => attr.Name).Contains(preferenceAttribute.Name) &&
                        item.Attributes.FirstOrDefault(x => x.Name == preferenceAttribute.Name)?.Value ==
                        preferenceAttribute.Value) {
                        percent += preferenceAttribute.Weight / model.PreferenceAttributes.Sum(x => x.Weight) * 100;
                    }
                }
                result.Add(new AssistantResultItemModel { Item = item.ToReportModel(), RateInPercent = Math.Round(percent, 2) });
            }

            return new AssistantResultModel() {
                Result = result.OrderByDescending(x => x.RateInPercent).ToList()
            };
        }
    }
}