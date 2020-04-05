using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models;

namespace ViewModels
{
    public class ListEventsViewModel
    {
          public Event Event { get; set; }
            public List<Event> Events { get; set; }
         public List<Address> Addresses { get; set; }
          public List<Business> Businesses { get; set; }

         
    }
}
