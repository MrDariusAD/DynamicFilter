using System;
using DynamicFilter.Domain.Core;
using DynamicFilter.Domain.Core.Models;
using DynamicFilter.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DynamicFilter.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AssistantController : ControllerBase {
        [HttpPost]
        [Route("CalculateOptimalItems")]
        public IActionResult CalculateOptimalItem(AssistantRequestModel model) {
            if (!CheckLicense())
                return Unauthorized("Product not licensed");
            try {
                MongoDb.MongoDb.Connect("mongodb://h2872984.stratoserver.net:27017/DynamicFilter?ssl=false");
                return Ok(AssistantService.CalculateOptimalItems(model, MongoDb.MongoDb.Load()));
            }
            catch (Exception e) {
                return StatusCode(500, e);
            }
        }

        private bool CheckLicense() {
            return Licensing.Licencsing.CheckLicense(Licensing.Licencsing.LicenseKey ?? "");
        }
    }
}