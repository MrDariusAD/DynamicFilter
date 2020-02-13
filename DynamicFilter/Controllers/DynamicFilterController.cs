using System;
using DynamicFilter.Domain.Core.Models;
using Microsoft.AspNetCore.Mvc;
using static DynamicFilter.MongoDb.MongoDb;

namespace DynamicFilter.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicFilterController : ControllerBase {
        [HttpGet]
        [Route("LoadAllItems")]
        public IActionResult LoadAllItems() {
            try {
                Connect("localhost");
                return Ok(Load());
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
                return Ok(Load(id));
            }
            catch (Exception e) {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Route("LoadWithFilter")]
        public IActionResult LoadWithFilter(Item filterItem) {
            try {
                Connect("localhost");
                return Ok(Load(filterItem));
            }
            catch (Exception e) {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Route("SaveItem")]
        public IActionResult SaveItem(Item toSave) {
            try {
                Connect("localhost");
                Save(toSave);
                return Ok();
            }
            catch (Exception e) {
                return StatusCode(500, e);
            }
        }
    }
}