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

        public EventController(ILogger<HomeController> logger, IEventServices eventServices, IEventTypeServices eventTypeServices)
        {
            _logger = logger;
            _eventServices = eventServices;
            _eventTypeServices = eventTypeServices;
        }


        /// <summary>
        ///     Page that display a list of Event that depend on specific criteria
        /// </summary>
        public async Task<IActionResult> Index([FromQuery(Name = "type")] string type)
        {
            IActionResult result = null;
            var events = await (string.IsNullOrEmpty(type) ? _eventServices.GetAll() : _eventTypeServices.GetEventsFromEventTypeName(type));

            if(events == null)
            {
                result = NotFound();
            }
            else
            {
                var model = new ListEventsViewModel { Events = events };
                result = View(model);
            }

            return result;
        }

        /// <summary>
        ///     Page that display the information about a single Event.
        /// </summary>
        /// <param name="id">The id of the event</param>
        [Route("Event/{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            IActionResult result = null;
            var oneEvent = await _eventServices.Get(id);

            if (oneEvent == null)
            {
                result = NotFound();
            }
            else
            {
                var model = new EventViewModel { Event = oneEvent };
                result = View("Event", model);
            }

            return result;
        }
    }
}