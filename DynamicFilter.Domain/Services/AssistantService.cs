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

                if (model.PreferenceAttributeGroups != null) {


                    foreach (var preferenceAttributeGroup in model.PreferenceAttributeGroups) {
                        foreach (var preferencedAttribute in preferenceAttributeGroup.Attributes) {
                            var hasAttribute = item.AttributeGroups
                                                   .FirstOrDefault(x => x.Name == preferenceAttributeGroup.Name) !=
                                               null;
                            var hasValue = item.AttributeGroups
                                               .FirstOrDefault(x => x.Name == preferenceAttributeGroup.Name)?.Attributes
                                               .FirstOrDefault(x => x.Name == preferencedAttribute.Name)?.Value ==
                                           preferencedAttribute.Value;
                            if (hasAttribute && hasValue) {
                                percent += preferencedAttribute.Weight / model.GetMergedAttributes().Sum(x => x.Weight) * 100;
                            }
                        }
                    }
                }
                if (model.PreferenceAttributes != null) {
                    foreach (var preferencedAttribute in model.PreferenceAttributes) {
                        if (item.GetMergedAttributes().Select(attr => attr.Name).Contains(preferencedAttribute.Name) &&
                            item.GetMergedAttributes().FirstOrDefault(x => x.Name == preferencedAttribute.Name)?.Value ==
                            preferencedAttribute.Value) {
                            percent += preferencedAttribute.Weight / model.GetMergedAttributes().Sum(x => x.Weight) * 100;
                        }
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