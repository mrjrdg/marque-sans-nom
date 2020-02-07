namespace Models
{
    /// <summary>
    ///     Represent the relationship between an APPLICATION_USER and an EVENT.
    ///     
    ///     - A ApplicationUser can participate to more than one event.
    ///     - A Event can be participate by more than one ApplicationUser
    /// </summary>
    public class EventApplicationUser
    {

        /// <summary>
        /// The id of the ApplicationUser partipating at the event Event
        /// </summary>
        /// <value></value>
        public string ApplicationUserId { get; set; }

        /// <summary>
        ///    The ApplicationUser participating the event
        /// </summary>
        /// <value></value>
        public ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// The event id to which the ApplicationUser will participate
        /// </summary>
        /// <value></value>
        public int EventId { get; set; }

        /// <summary>
        /// The event to which the ApplicationUser will participate
        /// </summary>
        /// <value></value>
        public Event Event { get; set; }
    }
}