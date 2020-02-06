using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    ///     Regroup the methods that are mandatory to ALL the Managers.
    /// </summary>
    /// <typeparam name="T">The model type from which the method will be based on</typeparam>
    public interface IDatabaseServices<T>
    {
        Task<T> Edit(T model);
        Task<T> Create(T model);
        Task<T> Get(int id);
        Task<T> Delete(int id);
        Task<List<T>> GetAll();
    }
}