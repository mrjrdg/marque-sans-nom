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
using Managers;




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

        private readonly UserManagerSQL _userManager;




        public EventController(ILogger<HomeController> logger, IEventServices eventServices, IEventTypeServices eventTypeServices,
        AppDbContext context, IAddressServices addressServices, IBusinessServices businessServices, UserManagerSQL userManager)
        {
            _userManager = userManager;
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
        public async Task<IActionResult> Index([FromQuery(Name = "type")] string type, string search, string typeSearch)
        {

            var events = await _context.Events.ToListAsync();
            var eventypes = await _context.EventTypes.ToListAsync();
            if (!String.IsNullOrEmpty(search))
            {
                events = events.Where(c => c.Title.Contains(search)).ToList();//
                // .Where( s => s.EventType.Title.Equals(typeSearch)).ToList();  
                //  eventypes = eventypes.Where( x => x.Title.Contains(typeSearch)).ToList();


            }
            else if ((!String.IsNullOrEmpty(typeSearch)))
            {

                // events = events.Where(x => x.EventType.Title.Equals(typeSearch)).ToList();

                events = events.ToList().Where(x => x.EventType.Title == typeSearch).ToList();

                // eventypes = eventypes.Where( x => x.Title.Contains(typeSearch)).ToList();
            }

            else
            {

                events = await (string.IsNullOrEmpty(type) ? _eventServices.GetAll() : _eventTypeServices.GetEventsFromEventTypeName(type));
            }

            IActionResult result = null;

            var addresses = await _context.Addresses.ToListAsync();
            var businesses = await _context.Businesses.ToListAsync();
            var users = await _context.EventApplicationUsers.ToListAsync();

            var comments = await _context.Commentaires.ToListAsync();
            if (events == null)
            {
                result = NotFound();
            }
            else
            {

                var model = new ListEventsViewModel
                {
                    Events = events,
                    Addresses = addresses,
                    Businesses = businesses,
                    EventTypes = eventypes
                };

                foreach (var item in model.Events)
                {
                    var links = await _context.EventApplicationUsers
                .Where(x => x.EventId == item.Id)
                .ToListAsync();

                    foreach (var link in links)
                    {
                        var user = await _userManager
                            .FindByIdAsync(link.ApplicationUserId);

                        item.Members.Add(user);
                    }

                }
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

            var addresses = await _eventServices
                .GetAll();

            await _eventTypeServices.GetAll();

            var oneEvent = await _eventServices
                .Get(id);

            if (oneEvent == null)
            {
                result = NotFound();
            }
            else
            {
                var model = new EventViewModel { Event = oneEvent };
                model.Event.Address = await _addressServices.Get(oneEvent.Address.Id);
                model.Event.EventType = await _eventTypeServices.Get(oneEvent.EventType.Id);


                model.Event.Commentaires = await _context.Commentaires
                    .Where(x => x.EventId == oneEvent.Id)
                    .ToListAsync();

                var links = await _context.EventApplicationUsers
                    .Where(x => x.EventId == oneEvent.Id)
                    .ToListAsync();

                foreach (var link in links)
                {
                    var user = await _userManager
                        .FindByIdAsync(link.ApplicationUserId);

                    model.Event.Members.Add(user);
                }

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
            if (events == null)
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
        public async Task<IActionResult> CreateEvent(CreateEventView event1)
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

        //GET Join Page
        public async Task<IActionResult> Join([FromQuery(Name = "type")] string type)
        {
            var events = await (string.IsNullOrEmpty(type) ? _eventServices.GetAll() : _eventTypeServices.GetEventsFromEventTypeName(type));
            var addresses = await _context.Addresses.ToListAsync();
            var businesses = await _context.Businesses.ToListAsync();
            var eventypes = await _context.EventTypes.ToListAsync();


            ListEventsViewModel allEvents = new ListEventsViewModel();
            allEvents.Events = events;

            return View(allEvents);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Join(ListEventsViewModel event1)
        {
            var getUser = await _userManager
                .GetUserAsync(User);

            var oneEvent = await _eventServices
                .Get(event1.Event.Id);

            var link = new EventApplicationUser
            {
                ApplicationUserId = getUser.Id,
                EventId = oneEvent.Id
            };

            var eventUser = await _context.EventApplicationUsers
                .AddAsync(link);

            _context.Update(oneEvent);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Event/{id:int}")]
        public async Task<IActionResult> Commenter(int id, EventViewModel newComment)
        {


            Commentaire newCommentaire = new Commentaire();

            newCommentaire.EventId = id;
            newCommentaire.Content = newComment.commentaire;
            newCommentaire.User = await _userManager.GetUserAsync(User);
            _context.Commentaires.Add(newCommentaire);
            await _context.SaveChangesAsync();

            return RedirectToAction("GetEvent", new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Route("Event/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {

            var eventDelete = await _context.Events.FindAsync(id);


            var allComments = await _context.Commentaires.ToListAsync();

            foreach (var item in allComments)
            {
                var commentDelete = await _context.Commentaires.FindAsync(item.EventId);
                if (item.EventId == id)
                {
                    _context.Commentaires.Remove(commentDelete);

                }

            }

            await _context.SaveChangesAsync();

            _context.Events.Remove(eventDelete);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var addresses = await _context.Addresses.ToListAsync();
            var businesses = await _context.Businesses.ToListAsync();
            var eventypes = await _context.EventTypes.ToListAsync();


            CreateEventView viewModel = new CreateEventView();
            viewModel.Addresses = addresses;
            viewModel.Businesses = businesses;
            viewModel.EventTypes = eventypes;
            viewModel.Event = await _context.Events.FindAsync(id);




            // var model = await _context.Events.FindAsync(id);
            // await _addressServices.GetAll();
            // if (model == null)
            // {
            //     return NotFound();
            // }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateEventView model)
        {

            var eventToChange = await _context.Events.FindAsync(id);


            try
            {
                eventToChange.Title = model.Event.Title;
                eventToChange.Address = await _addressServices.Get(model.Event.Address.Id);
                eventToChange.Business = await _businessServices.Get(model.Event.Business.Id);
                eventToChange.EventType = await _context.EventTypes.FindAsync(model.Event.EventType.Id);
                eventToChange.Description = model.Event.Description;


                _context.Update(eventToChange);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(model.Event.Id))
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


        public IActionResult userList()
        {
            return View();
        }

        private bool EventExists(int id)
        {
            return _context.Businesses.Any(e => e.Id == id);
        }
    }
}