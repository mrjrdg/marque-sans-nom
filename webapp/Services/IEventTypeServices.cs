using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Services;

namespace Services
{
    public interface IEventTypeServices : IDatabaseServices<EventType>
    {
        /// <summary>
        /// Return a list of all the <see cref="Event"/>  associated with this <see cref="EventType"/> 
        /// </summary>
        /// <param name="eventTypeTitle">The name of the <see cref="EventType"/></param>
        /// <returns>Return a <see cref="List"/>  <see cref="Event"/> </returns>
        Task<List<Event>> GetEventsFromEventTypeName(string eventTypeTitle);   
    }
}