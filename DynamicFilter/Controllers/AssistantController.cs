﻿using System;
using DynamicFilter.Domain.Core;
using Microsoft.AspNetCore.Mvc;
using DynamicFilter.Domain.Services;

namespace DynamicFilter.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssistantController : ControllerBase
    {
        [HttpGet]
        [Route("CalculateOptimalItems")]
        public IActionResult CalculateOptimalItem(AssistantRequestReportModel reportModel) {
            try
            {
                MongoDb.MongoDb.Connect("localhost");
                return Ok(AssistantService.CalculateOptimalItems(reportModel, MongoDb.MongoDb.Load()));
            }
            catch (Exception e) {
                return StatusCode(500, e);
            }
        }
    }
}