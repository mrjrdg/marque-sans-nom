using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace webapp.Controllers
{
    public class ErrorController : Controller
    {

        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("Error/{StatusCode}")]
        public IActionResult HttpStatusCodeHandler(int StatusCode)
        {
            var errorInfos = HttpContext.Features
                .Get<IStatusCodeReExecuteFeature>();
            _logger.LogWarning($@"The following path : 
                    {errorInfos.OriginalPath}
                    {errorInfos.OriginalQueryString} 
                    has trigger and error {StatusCode}");
            return View("NotFound");
        }

        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionInfos = HttpContext.Features
                .Get<IExceptionHandlerPathFeature>();
            _logger.LogCritical($@"AN EXCEPTION AS OCCURED : 
                {exceptionInfos.Error} ON THE FOLLOWING PATH 
                {exceptionInfos.Path}");
            return View("Error");
        }
    }
}
