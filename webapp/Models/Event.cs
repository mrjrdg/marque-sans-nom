using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Event
    {
        /// <summary>
        ///     The event Id
        /// </summary>
        /// <value></value>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The title of the event
        /// </summary>
        /// <value></value>
        [Required]
        public string Title { get; set; }

        /// <summary>
        ///     The price per participation
        /// </summary>
        /// <value></value>
        [Required]
        public double PriceToPayToParticipate { get; set; }

        /// <summary>
        /// The start date of the event
        /// </summary>
        /// <value></value>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The end date of the event
        /// </summary>
        /// <value></value>
        [Required]
        public DateTime EndDate { get; set; }


        // FOREIGN KEY ONE TO MANY //

        /// <summary>
        ///     The type of the event
        /// </summary>
        /// <value></value>
        public EventType EventType { get; set; }

        /// <summary>
        ///     The address of the event
        /// </summary>
        /// <value></value>
        public Address Address { get; set; }

        /// <summary>
        ///     The enterprise hosting the event
        /// </summary>
        /// <value></value>
        public Entreprise Entreprise { get; set; }

        /// <summary>
        ///     The owner ApplicationUser of this event
        /// </summary>
        /// <value></value>
        public ApplicationUser ApplicationUser { get; set; }

        // FOREIGN KEY MANY TO MANY //

        /// <summary>
        ///     List all the ApplicationUsers participating at this event
        /// </summary>
        /// <value></value>
        public List<EventApplicationUser> Members { get; set; }
    }
}