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



namespace Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntrepriseServices _entrepriseServices;

        public HomeController(ILogger<HomeController> logger, IEntrepriseServices entrepriseServices)
        {
            _logger = logger;
            _entrepriseServices = entrepriseServices;
        }


        public async Task<IActionResult> IndexAsync()
        {
            var model = new HomeViewModel();

            model.Entreprises = await _entrepriseServices.GetAll();
            //model.Events = new List<Event>();

            return View(model);
        }

        public IActionResult Privacy()
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