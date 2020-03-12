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
    public class EventController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventServices _eventServices;
        private readonly IEventTypeServices _eventTypeServices;

        private readonly IAddressServices _addressServices;

         private readonly IBusinessServices _businessServices;

        private readonly AppDbContext _context;

        public EventController(ILogger<HomeController> logger, IEventServices eventServices, IEventTypeServices eventTypeServices, 
        AppDbContext context, IAddressServices addressServices, IBusinessServices businessServices)
        {
            _logger = logger;
            _eventServices = eventServices;
            _eventTypeServices = eventTypeServices;
            _context = context;
            _addressServices = addressServices;
            _businessServices = businessServices;
        }


        /// <summary>
        ///     Page that display a list of Event that depend on specific criteria
        /// </summary>
        public async Task<IActionResult> Index([FromQuery(Name = "type")] string type)
        {
            IActionResult result = null;
            var events = await (string.IsNullOrEmpty(type) ? _eventServices.GetAll() : _eventTypeServices.GetEventsFromEventTypeName(type));
           var addresses = await _context.Addresses.ToListAsync();
           var businesses = await _context.Businesses.ToListAsync();
            if(events == null)
            {
                result = NotFound();
            }
            else
            {
                var model = new ListEventsViewModel { Events = events , Addresses = addresses,Businesses = businesses };
   
                result = View(model);
            }

            return result;
        }

        /// <summary>
        ///     Page that display the information about a single Event.
        /// </summary>
        /// <param name="id">The id of the event</param>
        [Route("Event/{id:int}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            IActionResult result = null;
            var addresses = await _eventServices.GetAll();
            await _eventTypeServices.GetAll();
            // var oneEvent = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
            var oneEvent = await _eventServices.Get(id);

            if (oneEvent == null)
            {
                result = NotFound();
            }
            else
            {
                var model = new EventViewModel { Event = oneEvent };
                model.Event.Address = await _addressServices.Get(oneEvent.Address.Id);
                model.Event.EventType = await _eventTypeServices.Get(oneEvent.EventType.Id);
                result = View("Event", model);
            }

            return result;
        }

         public async Task<IActionResult> CreateEvent([FromQuery(Name = "type")] string type)
        {
            IActionResult result = null;
            var events = await (string.IsNullOrEmpty(type) ? _eventServices.GetAll() : _eventTypeServices.GetEventsFromEventTypeName(type));
           var addresses = await _context.Addresses.ToListAsync();
           var businesses = await _context.Businesses.ToListAsync();
           var eventypes = await _context.EventTypes.ToListAsync();
            if(events == null)
            {
                result = NotFound();
            }
            else
            {
                        CreateEventView viewModel = new CreateEventView();
                        viewModel.Addresses = addresses;
                        viewModel.Businesses = businesses;
                        viewModel.EventTypes = eventypes;
   
                result = View(viewModel);
            }

            return result;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEvent( CreateEventView event1)
        {
           

           event1.Event.Address = await _addressServices.Get(event1.Event.Address.Id);
           event1.Event.Business = await _businessServices.Get(event1.Event.Business.Id);
           event1.Event.EventType = await _context.EventTypes.FindAsync(event1.Event.EventType.Id);
           //[Bind("Id,AddressId,BusinessId,ApplicationUserId,StartDate,EndDate,PriceToPayToParticipate,Title,EventTypeId")]
            // if (ModelState.IsValid)
            // {
                _context.Add(event1.Event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            // }else {
            // return RedirectToAction(nameof(CreateEvent));
            
        }
    
       
         public IActionResult userList()
        {
            return View();
        }
    }
}