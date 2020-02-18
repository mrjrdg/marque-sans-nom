using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Services
{
    /// <summary>
    ///    Regroup the methods that are mandatory to the EntrepriseManager only
    /// </summary>
    public interface IEventServices : IDatabaseServices<Event>
    {
        
    }
}