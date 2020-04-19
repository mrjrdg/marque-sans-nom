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

        
        [StringLength(100), MinLength(2)]
        public string Descrption {get;set; } 

        [StringLength(50), MinLength(2)]
        public string ville {get;set;}

        /// <summary>
        ///     List all the event of in which the ApplicationUser participate.
        /// </summary>
        /// <value></value>
        public List<EventApplicationUser> EventsParticipation { get; set; }

        /// <summary>
        ///     List all the event of in which the ApplicationUser participate.
        /// </summary>
        /// <value></value>
        public List<Event> Events{ get; set; }
        public List<MessageConversation> MessageConversationsSender { get; set; }
        public List<MessageConversation> MessageConversationsReceiver { get; set; }
        public List<Message> Messages { get; set; }
        public Avatar Avatar { get; set; }

        // PROPERTY NOT BIND TO THE DATABASE //

        [NotMapped]
        [Display(Name = "Nom complet")]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
