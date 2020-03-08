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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<ApplicationUser> _signIngManager;

        private readonly IBusinessServices _businessServices;

        public HomeController(ILogger<HomeController> logger, IBusinessServices businessServices, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _businessServices = businessServices;
            _signIngManager = signInManager;
        }


        public async Task<IActionResult> IndexAsync()
        {
            var model = new HomeViewModel();

            model.Businesses = await _businessServices.GetAll();

            if (_signIngManager.IsSignedIn(User))
            {

                return RedirectToAction("Index", "Event");
            }
            else
            {
                return View(model);
            }
            //model.Events = new List<Event>();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}