using System;
using Services;
using Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Managers
{
    /// <summary>
    ///   This is the final class that the user need to instanciate or to provide to the dependency injection system to work with the <see cref="Event"/> entity type in the database.
    /// - The user can override the CRUD method implemented in the abstract class <see cref="NormalCrudOperationSQL<TEntity>"/> if needed.
    /// - If the user want to implement a method that is only specific to the Business entity type, declare it in the <see cref="IEventServices"/> then implement it in this class.
    /// - The only method that can be declared and implemented directly in this class are privates methods for the side logic or method that will be only needed for the SQL provider.
    /// </summary>
    public class EventManagerSQL : NormalCrudOperationSQL<Event>, IEventServices
    {
        public EventManagerSQL(AppDbContext context, ILogger<NormalCrudOperationSQL<Event>> logger) : base(context, logger)
        {

        }
         public override async Task<List<Event>> GetAll()
        {
            var entities = await _context.Events.Include(a => a.Address).Include(e => e.Business).Include(b => b.ApplicationUser).ToListAsync();
            return entities;
        }
    }
}