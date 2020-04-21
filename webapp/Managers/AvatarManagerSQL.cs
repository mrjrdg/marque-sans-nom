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
    ///   This is the final class that the user need to instanciate or to provide to the dependency injection system to work with the <see cref="Avatar"/> entity type in the database.
    /// - The user can override the CRUD method implemented in the abstract class <see cref="NormalCrudOperationSQL<TEntity>"/> if needed.
    /// - If the user want to implement a method that is only specific to the Business entity type, declare it in the <see cref="IAvatarServices"/> then implement it in this class.
    /// - The only method that can be declared and implemented directly in this class are privates methods for the side logic or method that will be only needed for the SQL provider.
    /// </summary>
    public class AvatarManagerSQL : NormalCrudOperationSQL<Avatar>, IAvatarServices
    {
        public AvatarManagerSQL(AppDbContext context, ILogger<NormalCrudOperationSQL<Avatar>> logger) : base(context, logger)
        {

        }

        public async Task<Avatar> Get(string id)
        {
            Avatar entity = null;

            try
            {
                entity = await _context.Set<Avatar>()
                    .AsNoTracking()
                    .FirstAsync(x => x.ApplicationUserId == id);
            }
            catch(Exception e)
            {
                entity = null;
            }

                
            return entity;
        }
    }
}