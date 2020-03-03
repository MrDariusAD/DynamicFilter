﻿using System;
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
            try {
                MongoDb.MongoDb.Connect("localhost");
                return Ok(AssistantService.CalculateOptimalItems(model, MongoDb.MongoDb.Load()));
            }
            catch (Exception e) {
                return StatusCode(500, e);
            }
        }
    }
}