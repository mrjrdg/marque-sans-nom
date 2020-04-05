using System;
using Services;
using Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Managers
{
    /// <summary>
    ///   This is the final class that the user need to instanciate or to provide to the dependency injection system to work with the <see cref="MessageConversation"/> entity type in the database.
    /// - The user can override the CRUD method implemented in the abstract class <see cref="NormalCrudOperationSQL<TEntity>"/> if needed.
    /// - If the user want to implement a method that is only specific to the Business entity type, declare it in the <see cref="IMessageConversationServices"/> then implement it in this class.
    /// - The only method that can be declared and implemented directly in this class are privates methods for the side logic or method that will be only needed for the SQL provider.
    /// </summary>
    public class MessageConversationManagerSQL : NormalCrudOperationSQL<MessageConversation>, IMessageConversationServices
    {
        public MessageConversationManagerSQL(AppDbContext context, ILogger<NormalCrudOperationSQL<MessageConversation>> logger) : base(context, logger)
        {
          
        }

        public async Task<List<MessageConversation>> GetAllMessageConversationsOfUser(IdentityUser user)
        {
            var conversations = await _context.MessageConversations
                .Where(x => x.SenderId == user.Id || x.ReceiverId == user.Id)
                .Include(x => x.Messages)
                    .ThenInclude(y => y.User)
                .Include(x => x.Messages)
                .Include(x => x.Receiver)
                .ToListAsync();

            return conversations;
        }
    }
}