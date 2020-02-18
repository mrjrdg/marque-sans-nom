using Models;
using Managers;

namespace Services
{
    /// <summary>
    ///    Regroup the methods that are mandatory to the EntrepriseManager only
    /// </summary>
    public interface IBusinessServices : IDatabaseServices<Business>
    {
    
    }
}