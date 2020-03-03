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
        [HttpGet]
        [Route("LoadAllItems")]
        public IActionResult LoadAllItems() {
            try {
                Connect("localhost");
                return Ok(Load().Select(x => x.ToReportModel()));
            }
            catch (Exception e) {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Route("LoadItem/{id}")]
        public IActionResult LoadItem(string id) {
            try {
                Connect("localhost");
                return Ok(Load(id).ToReportModel());
            }
            catch (Exception e) {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Route("LoadWithFilter")]
        public IActionResult LoadWithFilter(Item filterItem) {
            try {
                Connect("localhost");
                return Ok(Load(filterItem).Select(x => x.ToReportModel()));
            }
            catch (Exception e) {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Route("SaveItem")]
        public IActionResult SaveItem([FromBody] Item toSave) {
            try {
                Connect("localhost");
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
            try {
                Connect("localhost");
                var allItems = Load();
                var comparer = new AttributeComparer();
                var attributes = allItems.SelectMany(x => x.Attributes) as Attribute[] ?? allItems.SelectMany(x => x.Attributes).ToArray();
                var distinct = attributes.Distinct(comparer);

                var response = distinct.Select(attribute => new SearchAttributeModel {
                    Name = attribute.Name,
                    Type = attribute.Type,
                    Values = attributes.Where(x => x.Name == attribute.Name && x.Type == attribute.Type && x.Weight == attribute.Weight).Select(x => x.Value).Distinct().ToArray(),
                    Weight = attribute.Weight
                }).ToList();

                return Ok(response.OrderBy(x => x.Name));
            }
            catch (Exception e) {
                return StatusCode(500, e);
            }
        }
    }
}