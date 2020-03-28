using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicFilter.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicensingController : ControllerBase
    {
        [HttpGet]
        [Route("ActivateProduct")]
        public IActionResult ActivateProduct(string productKey) {
            Console.WriteLine(productKey);
            var theKeyIsValid = Licensing.Licencsing.CheckLicense(productKey);
            if (!theKeyIsValid) return BadRequest(false);
            Licensing.Licencsing.IsLicensed = true;
            return Accepted(true);
        }

        [HttpGet]
        [Route("CheckActivation")]
        public IActionResult CheckActivation() {
            return Ok(Licensing.Licencsing.CheckLicense(Licensing.Licencsing.LicenseKey ?? ""));
        }
    }
}