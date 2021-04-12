using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFT.RunDigitalCheckScanner.Services;

namespace EFT.RunDigitalCheckScanner.Api.Controllers
{   
    [ApiController]
    [Route("api")]
    public class DigitalCheckScannerController : ControllerBase
    {        
        private readonly ILogger<DigitalCheckScannerController> _logger;
        public DigitalCheckScannerController(ILogger<DigitalCheckScannerController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet("StartScan")]
        public IActionResult StartScan()
        {
            DCSStartScanner startScanner = new DCSStartScanner();
            startScanner.StartScanner();
            return this.Ok();
        }

    }
}
