using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapp.Models;
using webapp.Data;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

//    public ActionResult SatyaAcademicYear()  
//         {  
//             using (DatabaseContext dc = new DatabaseContext(DbContextOptions<DatabaseContext>))  
//             {  
//                 var v = dc.AcademicYears.OrderByDescending(a => a.AcademicYear1).ToList();  
//                 return PartialView("_AcademicYear", v);  
//             }  
//         }  

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

      
        public IActionResult Index()
        {
            return View();
        }

        //   public async Task<IActionResult> Partial()
        // {
        //     return PartialView("_EntrepriseShare",await _context.Entreprise.ToListAsync());
        // }
       

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
