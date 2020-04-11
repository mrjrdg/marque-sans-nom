using System.ComponentModel.DataAnnotations;
using Models;
using System.Collections.Generic;



namespace ViewModels
{

    public class CreateEventView{
        public Event Event { get; set; }

           public List<Address> Addresses { get; set; }
          public List<Business> Businesses { get; set; }

           public List<EventType> EventTypes { get; set; }

           

           public CreateEventView()
   {
       Event = new Event();
   }
    }
}