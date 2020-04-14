using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models;

namespace ViewModels
{
    public class ListEventsViewModel
    {
        [Display(Name = "Par type :")]
        public string typeSearch {get;set;}
          public Event Event { get; set; }
            public List<Event> Events { get; set; }
         public List<Address> Addresses { get; set; }
          public List<Business> Businesses { get; set; }

          public Commentaire Commentaire {get; set;}

          public List<EventType> EventTypes {get;set;}

         
    }
}
