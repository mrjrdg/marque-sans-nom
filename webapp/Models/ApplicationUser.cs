using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Models {
    public class ApplicationUser : IdentityUser 
    {
        
        /// <summary>
        ///     List all the event of in which the ApplicationUser participate.
        /// </summary>
        /// <value></value>
        public List<EventApplicationUser> EventsParticipation { get; set; }
    }
}
