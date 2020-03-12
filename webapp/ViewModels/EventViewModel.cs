using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models;

namespace ViewModels
{
    public class EventViewModel
    {
        public Event Event;
          public List<Address> Addresses { get; set; }

          public EventType eventType {get ; set; }
    }
}
