using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Models {
    public class ApplicationUser : IdentityUser 
    {
        [Required]
        [StringLength(50), MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50), MinLength(2)]
        public string LastName { get; set; }

        
        /// <summary>
        ///     List all the event of in which the ApplicationUser participate.
        /// </summary>
        /// <value></value>
        public List<EventApplicationUser> EventsParticipation { get; set; }

        // PROPERTY NOT BIND TO THE DATABASE //

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
