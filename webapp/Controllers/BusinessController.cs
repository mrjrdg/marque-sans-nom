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

               public BusinessController( IBusinessServices businessServices, AppDbContext context)
        { 
            _businessServices = businessServices;
            _context = context;
     
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
         ;
         await _context.Addresses.ToListAsync();
              await _context.Events.ToListAsync();

 


            return View(await _context.Businesses.ToListAsync());
        }
    }
}