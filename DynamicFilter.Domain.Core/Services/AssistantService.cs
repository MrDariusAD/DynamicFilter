using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicFilter.Domain.Core.Services
{
    public class AssistantService
    {
        public static List<AssistantResultReportModel> CalculateOptimalItem(AssistantRequestReportModel reportModel, List<Item> items)
        {
            var result = new List<AssistantResultReportModel>();
            foreach (var item in items)
            {
                result.Add(new AssistantResultReportModel {Item = item, RateInPercent = 0});
            }
            foreach (var preferenceAttribute in reportModel.PreferenceAttributes)
            {
                var hits = items.Where(x => x.Attributes.Select(attr => attr.Name).Contains(preferenceAttribute.Name));
                foreach (var hit in hits)
                {
                    if (hit.Attributes.FirstOrDefault(x => x.Name == preferenceAttribute.Name)?.Value !=
                        preferenceAttribute.Value) continue;
                    {
                        var resItem = result.FirstOrDefault(x => x.Item.Id == hit.Id);
                        var percent = (float)1 / reportModel.PreferenceAttributes.Count;
                        if (resItem != null)
                            resItem.RateInPercent +=  percent;
                    }
                }
            }

            return result.OrderByDescending(x=> x.RateInPercent).ToList();
        }
    }
}