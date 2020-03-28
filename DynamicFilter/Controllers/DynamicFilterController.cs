using System;
using System.Collections.Generic;
using System.Linq;
using DynamicFilter.Domain.Comparer;
using DynamicFilter.Domain.Core.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static DynamicFilter.MongoDb.MongoDb;
using Attribute = DynamicFilter.Domain.Core.Models.Attribute;

namespace DynamicFilter.WebApi.Controllers {
    [Route("api/DynamicFilter")]
    [ApiController]
    public class DynamicFilterController : ControllerBase {
        public bool CheckLicense() {
            return Licensing.Licencsing.CheckLicense(Licensing.Licencsing.LicenseKey ?? "");
        }

        [HttpGet]
        [Route("LoadAllItems")]
        public IActionResult LoadAllItems() {
            if (!CheckLicense()) return Unauthorized("Product not licensed");
            Console.WriteLine("Loading all items...");
            try {
                Connect("mongodb://h2872984.stratoserver.net:27017/DynamicFilter?ssl=false");
                return Ok(Load().Select(x => x.ToReportModel()));
            }
            catch (Exception e) {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Route("LoadItem/{id}")]
        public IActionResult LoadItem(string id) {
            if (!CheckLicense())
                return Unauthorized("Product not licensed");
            try {
                Connect("mongodb://h2872984.stratoserver.net:27017/DynamicFilter?ssl=false");
                return Ok(Load(id).ToReportModel());
            }
            catch (Exception e) {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Route("LoadWithFilter")]
        public IActionResult LoadWithFilter(Item filterItem) {
            if (!CheckLicense())
                return Unauthorized("Product not licensed");
            try {
                Connect("mongodb://h2872984.stratoserver.net:27017/DynamicFilter?ssl=false");
                return Ok(Load(filterItem).Select(x => x.ToReportModel()));
            }
            catch (Exception e) {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Route("SaveItem")]
        public IActionResult SaveItem([FromBody] Item toSave) {
            if (!CheckLicense())
                return Unauthorized("Product not licensed");
            try {
                Connect("mongodb://h2872984.stratoserver.net:27017/DynamicFilter?ssl=false");
                Save(toSave);
                return Ok();
            }
            catch (Exception e) {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Route("GetAllPresentAttributes")]
        public IActionResult GetAllPresentAttributes() {
            if (!CheckLicense())
                return Unauthorized("Product not licensed");
            try {
                Connect(
                    "mongodb://h2872984.stratoserver.net:27017/DynamicFilter?ssl=false");
                var allItems = Load();
                var comparer = new AttributeComparer();

                var attributes = allItems.SelectMany(x => x.Attributes) as Attribute[] ??
                                 allItems.SelectMany(x => x.Attributes).ToArray();
                var attributeGroups = allItems.SelectMany(x => x.AttributeGroups);
                var groupAttributes =
                    allItems.SelectMany(x => x.AttributeGroups).SelectMany(x => x.Attributes) as Attribute[]
                    ?? allItems.SelectMany(x => x.AttributeGroups).SelectMany(x => x.Attributes).ToArray();
                var distinctAttributes = attributes.Distinct(comparer);
                var distinctGroupAttributes = groupAttributes.Distinct(comparer);

                var searchAttributeGroupModels = new List<SearchAttributeGroupModel>();

                foreach (var groupName in attributeGroups.Select(x => x.Name).Distinct()) {

                    searchAttributeGroupModels.Add(new SearchAttributeGroupModel {
                        Name = groupName,
                        Attributes = attributeGroups.FirstOrDefault(x=> x.Name == groupName).Attributes.Select(
                            attribute => new SearchAttributeModel {
                                Name = attribute.Name,
                                Type = attribute.Type,
                                Values = groupAttributes.Where(x => x.Name == attribute.Name && x.Type == attribute.Type &&
                                                                    x.Weight == attribute.Weight).Select(x=> x.Value).Distinct().ToArray(),
                                Weight = attribute.Weight
                            }).ToList()
                    });
                }


                var response = new PresentAttributesReportModel {
                    Attributes = distinctAttributes.Select(attribute => new SearchAttributeModel {
                        Name = attribute.Name,
                        Type = attribute.Type,
                        Values = attributes
                            .Where(x => x.Name == attribute.Name && x.Type == attribute.Type &&
                                        x.Weight == attribute.Weight).Select(x => x.Value).Distinct().ToArray(),
                        Weight = attribute.Weight
                    }).ToList(),
                    AttributeGroups = searchAttributeGroupModels
                };

                return Ok(response);
            }
            catch (Exception e) {
                return StatusCode(500, e);
            }
        }
    }
}