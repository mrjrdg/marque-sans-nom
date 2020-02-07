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
        /// <summary>
        ///    Edit the <paramref name="model"/> pass as a parameter
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The updated <see cref="IDatabaseServices{T}"/></returns>
        Task<T> Edit(T model);

        /// <summary>
        /// Create the <paramref name="model"/> passed as a parameter
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The newly created <see cref="IDatabaseServices{T}"/></returns>
        Task<T> Create(T model);

        /// <summary>
        /// Get the <see cref="IDatabaseServices{T}"/> that is related to the <paramref name="id"/> passed as a parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The wanted <see cref="IDatabaseServices{T}"/></returns>
        Task<T> Get(int id);

        /// <summary>
        /// Delete the <see cref="IDatabaseServices{T}"/> related to the <paramref name="id"/> passed as a parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The deleted <see cref="IDatabaseServices{T}"/></returns>
        Task<T> Delete(int id);

        /// <summary>
        /// Get all the models
        /// </summary>
        /// <returns>A List<<see cref="IDatabaseServices{T}"/>> of all the <see cref="IDatabaseServices{T}"/></returns>
        Task<List<T>> GetAll();
    }
}