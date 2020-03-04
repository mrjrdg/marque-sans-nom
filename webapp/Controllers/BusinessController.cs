using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;
using Services;
using Microsoft.AspNetCore.Identity;

namespace Controllers
{
    public class BusinessController : Controller
    {
        private readonly IBusinessServices _businessServices;

        public readonly AppDbContext _context;
        private readonly ILogger<BusinessController> _logger;

        public BusinessController(IBusinessServices businessServices, AppDbContext context, ILogger<BusinessController> logger)
        {
            _businessServices = businessServices;
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var businesses = await _businessServices.GetAll();
            return View(businesses);
        }
    }
}