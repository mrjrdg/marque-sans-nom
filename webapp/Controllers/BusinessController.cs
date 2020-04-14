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

        private readonly IEventServices _eventServices;

        private readonly IAddressServices _addressServices;

        private readonly IEventTypeServices _eventTypeServices;
        public readonly AppDbContext _context;
        private readonly ILogger<BusinessController> _logger;

        public BusinessController(IBusinessServices businessServices, AppDbContext context, 
        ILogger<BusinessController> logger, IAddressServices addressServices, IEventServices eventServices,
        IEventTypeServices eventTypeServices)
        {
            _eventServices = eventServices;
            _businessServices = businessServices;
            _context = context;
            _logger = logger;
            _addressServices = addressServices;
            _eventTypeServices = eventTypeServices;
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Businesses.FindAsync(id);
            await _addressServices.GetAll();
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

         /// <summary>
        ///     Page that display the information about a single Event.
        /// </summary>
        /// <param name="id">The id of the event</param>
        [Route("Business/{id:int}")]
        public async Task<IActionResult> GetBusiness(int id)
        {
            IActionResult result = null;

            var addresses = await _eventServices
                .GetAll();

            await _businessServices.GetAll();
            

            var oneBusiness = await _businessServices
                .Get(id);

            if (oneBusiness == null)
            {
                result = NotFound();
            }
            else
            {
                
                var model = await _businessServices.Get(oneBusiness.Id);
                model.Address = await _addressServices.Get(oneBusiness.Address.Id);
                model.Events = await _context.Events.Where (x => x.Id == oneBusiness.Id).ToListAsync();
                // model.Events = await _eventServices.GetAll();
                await _eventTypeServices.GetAll();
              

                // var links = await _context.EventApplicationUsers
                //     .Where(x => x.EventId == oneEvent.Id)
                //     .ToListAsync();

            

                result = View("Business", model);
            }

            return result;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Business model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
               
        }
         public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Businesses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            
            return View(model);
        }

              // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           var business = await _context.Businesses
                .Include(x => x.Events)
                .FirstAsync(x => x.Id == id);

            await _eventServices.GetAll();

            var allComments = await _context.Commentaires.ToListAsync();
            await _context.EventApplicationUsers.ToListAsync();

            foreach (var item in business.Events)
            {

            foreach (var unComment in allComments)
            {
                var commentDelete = await _context.Commentaires.FindAsync(unComment.EventId);
                if (unComment.EventId == item.Id)
                {
                    _context.Commentaires.Remove(commentDelete);

                }

            }
                _context.Events.Remove(await _context.Events.FindAsync(item.Id));

                await _context.SaveChangesAsync();
            }

           

            _context.Businesses.Remove(business);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

         private bool BusinessExists(int id)
        {
            return _context.Businesses.Any(e => e.Id == id);
        }
    }
}