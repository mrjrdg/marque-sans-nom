using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models;

namespace ViewModels
{
    public class ListEventsViewModel
    {
        public List<Event> Events { get; set; }
    }
}
