using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Models
{
    public class EventType
    {

        /// <summary>
        /// The id of the event type
        /// </summary>
        /// <value></value>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The title of the event type
        /// </summary>
        /// <value></value>
        [Required]
        public string Title { get; set; }

        // FOREIGN KEY //

        public List<Event> Events {get; set;}
    }
}