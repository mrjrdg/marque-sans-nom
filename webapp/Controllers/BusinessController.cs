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

        private readonly IAddressServices _addressServices;
        public readonly AppDbContext _context;
        private readonly ILogger<BusinessController> _logger;

        public BusinessController(IBusinessServices businessServices, AppDbContext context, ILogger<BusinessController> logger, IAddressServices addressServices)
        {
            _businessServices = businessServices;
            _context = context;
            _logger = logger;
            _addressServices = addressServices;
        }

        public async Task<IActionResult> Index()
        {
            var businesses = await _businessServices.GetAll();
            return View(businesses);
        }

         public IActionResult Create()
        {
            CreateBusinessView viewModel = new CreateBusinessView();
            return View(viewModel);
        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBusinessView model)
        {
            _context.Add(model.address);
            await _context.SaveChangesAsync();
            Address newAddress = await _addressServices.Get(model.address.Id);
         model.business.Address = newAddress;

            _context.Add(model.business);


            
    
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }
    }
}